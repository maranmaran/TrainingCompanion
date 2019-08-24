using System;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseTypeExerciseProperty
    {
        public Guid Id { get; set; }

        public bool Show { get; set; }

        public virtual Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }

        public virtual Guid ExercisePropertyId { get; set; }
        public virtual ExerciseProperty ExerciseProperty { get; set; }
    }
}