using System;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseTypeLoadAccomodation
    {
        public Guid Id { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }

        public Guid LoadAccomodationId { get; set; }
        public virtual LoadAccomodation LoadAccomodation { get; set; }
    }
}
