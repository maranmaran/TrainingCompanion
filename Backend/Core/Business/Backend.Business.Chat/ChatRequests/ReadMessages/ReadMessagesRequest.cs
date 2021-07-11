using Backend.Business.Chat.Models;
using System.Collections.Generic;

namespace Backend.Business.Chat.ChatRequests.ReadMessages
{
    public class ReadMessagesRequest : MediatR.IRequest
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}