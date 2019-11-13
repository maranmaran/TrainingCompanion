using Amazon.Runtime.Internal;
using Backend.Service.Chat.NgChatModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Application.Business.Business.Chat.ReadMessages
{
    public class ReadMessagesRequest: IRequest<Unit>
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
