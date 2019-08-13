using Backend.Domain.Enum;
using MediatR;
using System;

namespace Backend.Application.Business.Business.Users.UpdateUser
{
    public class UpdateUserRequest : IRequest
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
