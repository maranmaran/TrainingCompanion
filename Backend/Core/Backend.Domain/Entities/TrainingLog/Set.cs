using System;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Set
    {
        public Guid Id { get; set; }

        public double Weight { get; set; }
        public double Reps { get; set; }
        public TimeSpan Time { get; set; }
        public double Rpe { get; set; }
        public double Rir { get; set; }
        public string Intensity { get; set; } // string ?
        public double Volume { get; set; }
        public string AverageVelocity { get; set; }  // string ?
        public double ProjectedMax { get; set; }

        public Guid ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}