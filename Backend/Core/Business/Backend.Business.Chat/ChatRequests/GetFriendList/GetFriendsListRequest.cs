using System;
using System.Collections.Generic;
using Backend.Business.Chat.Models;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Chat.ChatRequests.GetFriendList
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