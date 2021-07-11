using Backend.Business.Chat.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Chat.ChatRequests.GetChatHistoryFull
{
    public class GetChatHistoryFullRequest : IRequest<IEnumerable<MessageViewModel>>
    {
        public Guid UserId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}