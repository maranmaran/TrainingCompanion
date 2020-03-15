using System;

namespace Backend.Domain.Entities.Exercises
{
    public class ExerciseTypeTag
    {
        public Guid Id { get; set; }

        public bool Show { get; set; }

        public virtual Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }

        public virtual Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}