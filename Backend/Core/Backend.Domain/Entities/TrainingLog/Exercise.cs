using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType.ExerciseType ExerciseType { get; set; }

        public Guid TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public virtual ICollection<Set> Sets { get; set; } = new HashSet<Set>();
    }
}