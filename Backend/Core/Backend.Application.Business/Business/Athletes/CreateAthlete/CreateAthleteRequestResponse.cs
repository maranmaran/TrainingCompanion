using System;
using Backend.Domain.Entities;
using Backend.Domain.Enum;

namespace Backend.Application.Business.Business.Athletes.CreateAthlete
{
    public class CreateAthleteRequestResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
        public AccountStatus AccountStatus => AccountStatus.Waiting;
        public AccountType AccountType => AccountType.Athlete;
        public Guid ParentId { get; set; }
        public ApplicationUser Parent { get; set; }
    }
}
