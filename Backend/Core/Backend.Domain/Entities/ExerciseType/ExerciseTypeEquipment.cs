using System;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseTypeEquipment
    {
        public Guid Id { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }

        public Guid ExerciseTypePropertyId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}