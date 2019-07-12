using System;
using Backend.Application.Business.Business.Users.Commands.Create;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastModified => DateTime.UtcNow;
        public AccountStatus AccountStatus { get; set; }
    }
}
