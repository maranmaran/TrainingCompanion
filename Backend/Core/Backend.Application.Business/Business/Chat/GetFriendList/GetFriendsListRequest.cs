using Backend.Domain.Enum;
using Backend.Service.Chat.NgChatModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.Chat.GetFriendList
{
    public class GetFriendsListRequest : IRequest<IEnumerable<ParticipantResponseViewModel>>
    {
        public Guid UserId { get; set; }
        public AccountType AccountType { get; set; }

        public GetFriendsListRequest(Guid userId, AccountType accountType)
        {
            UserId = userId;
            AccountType = accountType;
        }

        public GetFriendsListRequest(string userId, AccountType accountType)
        {
            UserId = Guid.Parse(userId);
            AccountType = accountType;
        }
    }
}