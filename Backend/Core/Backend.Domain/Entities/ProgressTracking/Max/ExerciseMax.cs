using System;
using Backend.Domain.Entities.User;

namespace Backend.Domain.Entities.ProgressTracking.Max
{
    public class ExerciseMax
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType.ExerciseType ExerciseType { get; set; }

        public double Max { get; set; }

        public double WilksScore { get; set; }
        public double IpfPoints { get; set; }
    }
}