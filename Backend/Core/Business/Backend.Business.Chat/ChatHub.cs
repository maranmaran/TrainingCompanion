using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business.Chat.ChatRequests.CreateChatMessage;
using Backend.Business.Chat.ChatRequests.ReadMessages;
using Backend.Business.Chat.Models;
using Backend.Business.Users.UsersRequests.GetUser;
using Backend.Domain.Enum;
using Backend.Service.AmazonS3.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Business.Chat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, ParticipantResponseViewModel> AllConnectedParticipants { get; set; } = new ConcurrentDictionary<string, ParticipantResponseViewModel>();
        private static ConcurrentDictionary<string, ParticipantResponseViewModel> DisconnectedParticipants { get; set; } = new ConcurrentDictionary<string, ParticipantResponseViewModel>();

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IS3AccessService _s3AccessService;

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
        public async Task SendMessage(MessageViewModel message)
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
        public async Task MessagesSeen(IEnumerable<MessageViewModel> messages)
        {
            await _mediator.Send(new ReadMessagesRequest() { Messages = messages });
        }

        /// <summary>
        /// Disconnected handler
        /// Switches user to different pool for disconnected users and updates his status to offline
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User.Identity.Name;
            AllConnectedParticipants.TryGetValue(userId, out var participant);

            if (participant != null)
            {
                participant.Participant.Status = ChatParticipantStatus.Offline;

                AllConnectedParticipants.TryRemove(userId, out var removedParticipant);
                DisconnectedParticipants.TryAdd(userId, removedParticipant);

                await Clients.All.SendAsync("friendsListChanged");
            }
        }

        /// <summary>
        /// Connected handler
        /// Switches user to different pool for connected users and updates his status to online
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
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

                await Clients.All.SendAsync("friendsListChanged");
            }

            // if participant doesn't exist in disconnected dict. Fetch user and move it to Connected dictionary
            if (disconnectedParticipant == null && connectedParticipant == null)
            {
                var user = await _mediator.Send(new GetUserRequest(Guid.Parse(userId), AccountType.User));
                var newParticipant = _mapper.Map<ParticipantResponseViewModel>(user);

                newParticipant.Participant.Status = ChatParticipantStatus.Online;

                AllConnectedParticipants.TryAdd(userId, newParticipant);
            }
            // else if connected participant exists.. do nothing because user probably logged in on multiple browsers
        }
    }
}