using System;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Users.Users.UpdateUser
{
    public class UpdateUserRequest : IRequest<ApplicationUser>
    {
        public Guid Id { get; set; }
        public AccountType AccountType { get; set; }

        public bool Active { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}