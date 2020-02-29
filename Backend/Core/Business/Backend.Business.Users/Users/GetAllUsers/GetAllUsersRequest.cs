using System;
using System.Linq;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Users.Users.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<IQueryable<ApplicationUser>>
    {
        public AccountType AccountType { get; set; }
        public Guid CoachId { get; set; }

        public GetAllUsersRequest(AccountType accountType, Guid coachId)
        {
            AccountType = accountType;
            CoachId = coachId;
        }
    }
}