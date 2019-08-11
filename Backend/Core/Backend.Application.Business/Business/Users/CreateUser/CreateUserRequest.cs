using Backend.Domain.Enum;
using MediatR;
using System;
using Backend.Domain.Entities;

namespace Backend.Application.Business.Business.Users.CreateUser
{
    public class CreateUserRequest : IRequest<ApplicationUser>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;
        public DateTime LastModified => CreatedOn;
        public bool Active => true;
        public AccountType AccountType { get; set; }
        public Gender Gender { get; set; }
    }
}
