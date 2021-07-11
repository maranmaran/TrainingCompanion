using MediatR;
using System;

namespace Backend.Business.Authorization.AuthorizationRequests.CurrentUser
{
    public class CurrentUserRequest : IRequest<CurrentUserRequestResponse>
    {
        public Guid UserId { get; set; }

        public CurrentUserRequest(string userId)
        {
            UserId = Guid.Parse(userId);
        }

        public CurrentUserRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}