

using System;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Users.GetUser
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
