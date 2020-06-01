using System;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Set
    {
        public Guid Id { get; set; }

        // strength training
        public double Weight { get; set; }
        public double Rpe { get; set; }
        public double Rir { get; set; }
        public double Reps { get; set; }
        public double Percentage { get; set; } // 1-100
        public double MaxUsedForPercentage { get; set; }

        // endurance
        public TimeSpan Time { get; set; }
        public double Distance { get; set; } // meters
        public double Power { get; set; } // watts


        // if it can be calculated for statistics
        public string Intensity { get; set; } // string ?
        public double Volume { get; set; }
        public double ProjectedMax { get; set; }

        // velocity based
        public string AverageVelocity { get; set; }  // string ?


        public Guid ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}