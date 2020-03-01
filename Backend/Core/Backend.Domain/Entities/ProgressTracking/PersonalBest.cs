using System;

namespace Backend.Domain.Entities.ProgressTracking
{
    public class PersonalBest
    {
        public Guid Id { get; set; }

        public double Value { get; set; } //KG 
        public DateTime DateAchieved { get; set; }

        public double? Bodyweight { get; set; }
        public double WilksScore { get; set; }
        public double IpfPoints { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType.ExerciseType ExerciseType { get; set; }
    }
}