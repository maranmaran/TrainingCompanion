using Backend.Domain.Entities.User;
using System;

namespace Backend.Domain.Entities.ProgressTracking
{
    public class Bodyweight
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}