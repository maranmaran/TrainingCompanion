using System;
using System.Collections.Generic;
using Backend.Service.Chat.NgChatModels;
using MediatR;

namespace Backend.Application.Business.Business.Chat.GetChatHistory
{
    public class GetChatHistoryRequest : IRequest<IEnumerable<MessageViewModel>>
    {
        public Guid UserId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
