using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;
using System;

namespace Backend.Business.Users.UsersRequests.CreateUser
{
    public class CreateUserRequest : IRequest<ApplicationUser>
    {
        public AccountType AccountType { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public Guid CoachId { get; set; }
    }
}