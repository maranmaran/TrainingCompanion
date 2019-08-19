using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public int Sets { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType.ExerciseType ExerciseType { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; } = new HashSet<Lift>();
    }
}