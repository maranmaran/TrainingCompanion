using System;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Lift
    {
        public Guid Id { get; set; }

        public double Weight { get; set; }
        public double Reps { get; set; }
        public TimeSpan Time { get; set; }
        public double Rpe { get; set; }
        public string Intensity { get; set; }
        public double Volume { get; set; }
        public string AverageVelocity { get; set; }
        public double ProjectedMax { get; set; }
    }
}