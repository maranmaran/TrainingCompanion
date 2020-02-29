using System;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Users.Users.GetUser
{
    public class GetUserRequest : IRequest<ApplicationUser>
    {
        public Guid Id { get; set; }
        public AccountType AccountType { get; set; }

        public GetUserRequest(Guid id, AccountType accountType)
        {
            Id = id;
            AccountType = accountType;
        }
    }
}