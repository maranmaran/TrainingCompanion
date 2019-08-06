using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Athletes.UpdateAthlete
{
    public class UpdateAthleteRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastModified => DateTime.UtcNow;
        public AccountStatus AccountStatus { get; set; }
    }
}
