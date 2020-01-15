using System;

namespace Backend.Domain.Entities.ProgressTracking.Max
{
    public class ExerciseMax
    {
        public Guid Id { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType.ExerciseType ExerciseType { get; set; }

        public DateTime DateAchieved { get; set; }

        public double Max { get; set; }

        public double WilksScore { get; set; }
        public double IpfPoints { get; set; }
    }
}