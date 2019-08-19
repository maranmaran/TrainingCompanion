using System;

namespace Backend.Domain.Entities.ExerciseType.Properties
{
    public class RangeOfMotion
    {
        public Guid Id { get; set; }
        public string Value { get; set; }

        public int Order { get; set; }
        public bool Active { get; set; }
    }
}