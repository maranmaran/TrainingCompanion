using System;
using MediatR;

namespace Backend.Application.Business.Business.Authorization.CurrentUser
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
