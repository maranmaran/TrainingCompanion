using System;
using System.Collections.Generic;
using Backend.Service.Chat.NgChatModels;
using MediatR;

namespace Backend.Application.Business.Business.Chat.Queries.GetFriendListQuery
{
    public class GetFriendsListQuery : IRequest<IEnumerable<ParticipantResponseViewModel>>
    {
        public Guid UserId { get; set; }

        public GetFriendsListQuery(Guid userId)
        {
            UserId = userId;
        }

        public GetFriendsListQuery(string userId)
        {
            UserId = Guid.Parse(userId);
        }
    }
}
