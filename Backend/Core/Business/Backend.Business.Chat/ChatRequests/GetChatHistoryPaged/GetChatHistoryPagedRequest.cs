using Backend.Business.Chat.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Chat.ChatRequests.GetChatHistoryPaged
{

    public class GetChatHistoryPagedRequest : IRequest<IEnumerable<MessageViewModel>>
    {
        public Guid UserId { get; set; }
        public Guid ReceiverId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetChatHistoryPagedRequest(IEnumerable<MessageViewModel> entity)
        {
        }
    }
}
