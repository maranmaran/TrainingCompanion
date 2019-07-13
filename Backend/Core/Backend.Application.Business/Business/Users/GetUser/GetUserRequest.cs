using System;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Users.GetUser
{
    public class GetUserRequest : IRequest<ApplicationUser>
    {
        public Guid UserId { get; set; }

        public GetUserRequest(Guid id)
        {
            UserId = id;
        }
    }
}
