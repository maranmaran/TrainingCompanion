using System.Collections.Generic;
using Backend.Business.Chat.Models;

namespace Backend.Business.Chat.Chat.ReadMessages
{
    public class ReadMessagesRequest : MediatR.IRequest
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}