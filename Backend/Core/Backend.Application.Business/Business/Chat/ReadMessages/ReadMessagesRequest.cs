using Backend.Service.Chat.NgChatModels;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.Chat.ReadMessages
{
    public class ReadMessagesRequest : MediatR.IRequest
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}