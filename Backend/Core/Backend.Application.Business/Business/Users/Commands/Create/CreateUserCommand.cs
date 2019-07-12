﻿using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;
        public DateTime LastModified => CreatedOn;
        public AccountStatus AccountStatus => AccountStatus.Active;
        public AccountType AccountType => AccountType.User;
    }
}
