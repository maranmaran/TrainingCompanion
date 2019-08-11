using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Coaches.UpdateCoach
{
    public class UpdateCoachRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastModified => DateTime.UtcNow;
        public bool Active { get; set; }
        public Gender Gender { get; set; }
    }
}
