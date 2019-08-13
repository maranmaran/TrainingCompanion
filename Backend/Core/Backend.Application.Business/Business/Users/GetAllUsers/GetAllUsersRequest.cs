using System;
using System.Linq;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Users.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<IQueryable<ApplicationUser>>
    {
        public AccountType AccountType { get; set; }
        public Guid CoachId { get; set; }
    }
}
