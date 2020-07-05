using Backend.Domain.Entities.User;
using MediatR;
using System;

namespace Backend.Business.Users.UsersRequests.GetUser
{
    public class GetUserRequest : IRequest<ApplicationUser>
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }

        public GetUserRequest(Guid? id = null, string email = null)
        {
            Id = id;
            Email = email;
        }
    }
}