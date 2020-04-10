using System;

namespace Backend.Domain.Deserializators
{
    public class PersonalBestDeserializeResult
    {
        public Guid Id { get; set; }

        public double Value { get; set; } //KG 
        public DateTime DateAchieved { get; set; }

        public double? Bodyweight { get; set; }
        public double WilksScore { get; set; }
        public double IpfPoints { get; set; }

        public Guid ExerciseTypeId { get; set; }
    }
}