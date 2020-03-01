using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Users.UsersRequests.DeleteUser
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