using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public Guid Id { get; set; }
        public AccountType AccountType { get; set; }

        public DeleteUserRequest(Guid id, AccountType accountType)
        {
            Id = id;
            AccountType = accountType;
        }
    }
}
