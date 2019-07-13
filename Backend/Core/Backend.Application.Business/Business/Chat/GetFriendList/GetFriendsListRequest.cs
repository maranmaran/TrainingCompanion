using System;
using System.Collections.Generic;
using Backend.Service.Chat.NgChatModels;
using MediatR;

namespace Backend.Application.Business.Business.Chat.GetFriendList
{
    public class GetFriendsListRequest : IRequest<IEnumerable<ParticipantResponseViewModel>>
    {
        public Guid UserId { get; set; }

        public GetFriendsListRequest(Guid userId)
        {
            UserId = userId;
        }

        public GetFriendsListRequest(string userId)
        {
            UserId = Guid.Parse(userId);
        }
    }
}
