using System;
using System.Collections.Generic;
using Backend.Business.Chat.Models;
using MediatR;

namespace Backend.Business.Chat.ChatRequests.GetChatHistory
{
    public class GetChatHistoryRequest : IRequest<IEnumerable<MessageViewModel>>
    {
        public Guid UserId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}