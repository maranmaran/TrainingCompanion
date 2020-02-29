using System;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Users.Users.CreateUser
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