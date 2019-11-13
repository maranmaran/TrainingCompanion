using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.AmazonS3.Models;
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
using Backend.Domain.Entities.Chat;
using MediatR;
using Backend.Application.Business.Business.Chat.ReadMessages;
using Backend.Application.Business.Business.Chat.CreateChatMessage;

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

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IS3AccessService _s3AccessService;
        //private bool _init = false;

        public ChatHub(IMediator mediator, IMapper mapper, IS3AccessService s3AccessService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _s3AccessService = s3AccessService;
        }


        /// <summary>
        /// Handler for message sending.
        /// Persists message in database and then sends it through the hub to listeners
        /// </summary>
        /// <param name="message"></param>
        public async void SendMessage(MessageViewModel message)
        {
            var createRequest = _mapper.Map<MessageViewModel, CreateChatMessageRequest>(message);
            await _mediator.Send(createRequest);

            var sender = AllConnectedParticipants.FirstOrDefault(x => x.Key == message.FromId);
            if (sender.Value != null)
            {
                // get fresh presigned url for display
                message.DownloadUrl = await _s3AccessService.RenewPresignedUrl(message.DownloadUrl, message.S3Filename);

                // send message
                await Clients.User(message.ToId).SendAsync("messageReceived", sender.Value.Participant, message);
            }
        }

        /// <summary>
        /// Handler for message seen.
        /// Persists seen attribute in database
        /// </summary>
        /// <param name="message"></param>
        public async void MessagesSeen(IEnumerable<MessageViewModel> messages)
        {
            await _mediator.Send(new ReadMessagesRequest() {  Messages = messages });
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
                //else
                //{
                //    throw new InvalidOperationException("ApplicationUser can't be disconnecting if he never connected");
                //}

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