using Backend.Domain.Entities.Exercises;
using System;

namespace Backend.Domain.Entities.ProgressTracking
{
    public class PersonalBest
    {
        public Guid Id { get; set; }

        public double Value { get; set; } //KG 
        public double? Reps { get; set; }
        public DateTime DateAchieved { get; set; }


        // meaning projected from app itself
        // false if user inserted this PR
        public bool SystemCalculated { get; set; }

        public double? Bodyweight { get; set; }
        public double WilksScore { get; set; }
        public double IpfPoints { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
    }
}