using Backend.Domain.Entities;
using Backend.Domain.Enum;
using MediatR;
using System;
using Backend.Domain.Entities.User;

namespace Backend.Application.Business.Business.Users.CreateUser
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
