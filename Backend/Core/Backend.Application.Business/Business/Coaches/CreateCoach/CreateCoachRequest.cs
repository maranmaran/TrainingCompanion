using System;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Coaches.CreateCoach
{
    public class CreateCoachRequest : IRequest<Coach>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;
        public DateTime LastModified => CreatedOn;
        public bool Active => true;
        public Gender Gender { get; set; }
        public AccountType AccountType => AccountType.Coach;
    }
}
