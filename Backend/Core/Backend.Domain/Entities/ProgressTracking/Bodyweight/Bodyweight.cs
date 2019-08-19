using System;
using Backend.Domain.Entities.User;

namespace Backend.Domain.Entities.ProgressTracking.Bodyweight
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
