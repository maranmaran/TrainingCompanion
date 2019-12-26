using Backend.Domain.Enum;
using MediatR;
using System;

namespace Backend.Application.Business.Business.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest<Unit>
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