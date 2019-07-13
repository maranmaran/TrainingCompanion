using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Chat.NgChatModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Chat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, ParticipantResponseViewModel> AllConnectedParticipants { get; set; } = new ConcurrentDictionary<string, ParticipantResponseViewModel>();
        private static ConcurrentDictionary<string, ParticipantResponseViewModel> DisconnectedParticipants { get; set; } = new ConcurrentDictionary<string, ParticipantResponseViewModel>();

        private readonly object _initLock = new object();
        private static readonly object ConnectedParticipantsLock = new object();
        private readonly object _messageLock = new object();
        private readonly object _messagesLock = new object();
        private readonly object _connectedLock = new object();
        private readonly object _disconnectedLock = new object();
        private readonly object _contextLock = new object();

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        //private bool _init = false;

        public ChatHub(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            //DoInit();
        }

        /// <summary>
        /// Initializes state of hub and all existing users pool
        /// </summary>
        //private void DoInit()
        //{
        //    lock (_initLock)
        //    {
        //        lock (_contextLock)
        //        {
        //            if (!_init)
        //            {
        //                var users = _mapper.Map<HashSet<ParticipantResponseViewModel>>(_context.Users.AsNoTracking().ToList());

        //                foreach (var user in users)
        //                {
        //                    if (!AllConnectedParticipants.TryGetValue(user.Participant.Id, out _))
        //                    {

        //                        if (!DisconnectedParticipants.TryGetValue(user.Participant.Id, out _))
        //                        {
        //                            DisconnectedParticipants.TryAdd(user.Participant.Id, user);
        //                        }
        //                    }
        //                }

        //                _init = true;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Gets connected and disconnected participants from given array of wanted users 
        /// </summary>
        /// <returns></returns>
        //public static IEnumerable<ParticipantResponseViewModel> ConnectedParticipants(IEnumerable<string> userIdsToRetrieve)
        //{
        //    lock (ConnectedParticipantsLock)
        //    {
        //        var connectedUsers = AllConnectedParticipants.Where(x => userIdsToRetrieve.Any(y => y.ToLower() == x.Key.ToLower())).Select(x => x.Value);
        //        var disconnectedUsers = DisconnectedParticipants.Where(x => userIdsToRetrieve.Any(y => y.ToLower() == x.Key.ToLower())).Select(x => x.Value);

        //        return connectedUsers.Concat(disconnectedUsers);
        //    }
        //}

        /// <summary>
        /// Handler for message sending.
        /// Persists message in database and then sends it through the hub to listeners
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(MessageViewModel message)
        {
            lock (_messageLock)
            {
                var sender = AllConnectedParticipants.FirstOrDefault(x => x.Key == message.FromId);

                lock (_contextLock)
                {
                    _context.ChatMessages.Add(new ChatMessage()
                    {
                        Message = message.Message,
                        SenderId = Guid.Parse(message.FromId),
                        ReceiverId = Guid.Parse(message.ToId),
                        SentAt = DateTime.UtcNow,
                        Type = (MessageType)Enum.Parse(typeof(MessageType), message.Type.ToString()),
                        SeenAt = message.DateSeen,
                        DownloadUrl = message.DownloadUrl,
                        FileSizeInBytes = message.FileSizeInBytes,
                    });

                    _context.SaveChangesAsync(CancellationToken.None).Wait();
                }

                if (sender.Value != null)
                {
                    Clients.User(message.ToId).SendAsync("messageReceived", sender.Value.Participant, message);
                }
            }
        }

        /// <summary>
        /// Handler for message seen.
        /// Persists seen attribute in database
        /// </summary>
        /// <param name="message"></param>
        public void MessagesSeen(IEnumerable<MessageViewModel> messages)
        {
            lock (_messagesLock)
            {
                lock (_contextLock)
                {
                    var chatMessagesToUpdate = new List<ChatMessage>();
                    foreach (var message in messages)
                    {
                        var chatMessageToUpdate = _context.ChatMessages
                            .SingleOrDefault(
                                x => String.Equals(x.SenderId.ToString(), message.FromId, StringComparison.CurrentCultureIgnoreCase)
                                    && String.Equals(x.ReceiverId.Value.ToString(), message.ToId, StringComparison.CurrentCultureIgnoreCase)
                                    && x.SentAt.ToUniversalTime() == message.DateSent.Value.ToUniversalTime());

                        if (chatMessageToUpdate != null)
                        {
                            chatMessageToUpdate.SeenAt = DateTime.UtcNow;
                            chatMessagesToUpdate.Add(chatMessageToUpdate);
                        }
                    }

                    if (chatMessagesToUpdate.Count > 0)
                    {
                        _context.ChatMessages.UpdateRange(chatMessagesToUpdate);
                        _context.SaveChangesAsync(CancellationToken.None).Wait();
                    }
                }
            }
        }

        /// <summary>
        /// Disconnected handler
        /// Switches user to different pool for disconnected users and updates his status to offline
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            lock (_disconnectedLock)
            {
                var userId = Context.User.Identity.Name;
                AllConnectedParticipants.TryGetValue(userId, out var participant);

                if (participant != null)
                {
                    participant.Participant.Status = ChatParticipantStatus.Offline;

                    AllConnectedParticipants.TryRemove(userId, out var removedParticipant);
                    DisconnectedParticipants.TryAdd(userId, removedParticipant);

                    Clients.All.SendAsync("friendsListChanged");
                }
                else
                {
                    throw new InvalidOperationException("User can't be disconnecting if he never connected");
                }

                return base.OnDisconnectedAsync(exception);
            }
        }

        /// <summary>
        /// Connected handler
        /// Switches user to different pool for connected users and updates his status to online
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {

            lock (_connectedLock)
            {

                var userId = Context.User.Identity.Name; // fetch id
                DisconnectedParticipants.TryGetValue(userId, out var disconnectedParticipant); // get from disconnected participants
                AllConnectedParticipants.TryGetValue(userId, out var connectedParticipant); // get from disconnected participants

                if (disconnectedParticipant != null && connectedParticipant == null)
                {
                    // if participant exists in disconnected dictionary. Move it to Connected
                    disconnectedParticipant.Participant.Status = ChatParticipantStatus.Online;

                    DisconnectedParticipants.TryRemove(userId, out var removedParticipant);
                    AllConnectedParticipants.TryAdd(userId, removedParticipant);

                    Clients.All.SendAsync("friendsListChanged");
                }

                // if participant doesn't exist in disconnected dict. Fetch user and move it to Connected dictionary
                if (disconnectedParticipant == null && connectedParticipant == null)
                {
                    var newParticipant = _mapper.Map<ParticipantResponseViewModel>(_context.Users.SingleAsync(x => x.Id.ToString() == userId).Result);
                    newParticipant.Participant.Status = ChatParticipantStatus.Online;
                    AllConnectedParticipants.TryAdd(userId, newParticipant);
                }

                // else if connected participant exists.. do nothing because user probably logged in two times on two browsers


                return base.OnConnectedAsync();
            }
        }
    }
}