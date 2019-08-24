using System;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseProperty
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        public virtual Guid ExercisePropertyTypeId { get; set; }
        public virtual ExercisePropertyType ExercisePropertyType { get; set; }
    }
}
