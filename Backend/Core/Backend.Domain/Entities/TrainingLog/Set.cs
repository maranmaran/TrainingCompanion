using System;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Set
    {
        public Guid Id { get; set; }

        // Strength training
        public double Weight { get; set; }
        public double Reps { get; set; }

        // Exertion stuff
        public bool UsesExertion { get; set; } // use RPE flag on frontend
        public double Rpe { get; set; }
        public double Rir { get; set; }

        // Percentage stuff
        public bool UsesPercentage { get; set; } // use Percentage flag on frontend
        public double Percentage { get; set; } // 1-100
        public double MaxUsedForPercentage { get; set; }

        // Endurance
        public TimeSpan Time { get; set; }
        public double Distance { get; set; } // meters
        public double Power { get; set; } // watts

        // If it can be calculated for statistics
        public string Intensity { get; set; } // string ?
        public double Volume { get; set; }
        public double ProjectedMax { get; set; }

        // Velocity based
        public string AverageVelocity { get; set; }  // string ?


        public Guid ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}