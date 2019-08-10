using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Athletes.CreateAthlete
{
    public class CreateAthleteRequest : IRequest<CreateAthleteRequestResponse>
    {
        public Guid CoachId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;
        public DateTime LastModified => CreatedOn;
        public AccountStatus AccountStatus => AccountStatus.Waiting;
        public AccountType AccountType => AccountType.Athlete;
        public Gender Gender;
    }
}
