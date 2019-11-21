using Backend.Domain.Entities.ProgressTracking.Max;
using Backend.Domain.Entities.User;
using System;
using System.Collections.Generic;
using Backend.Domain.Entities.TrainingLog;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public bool RequiresReps { get; set; }
        public bool RequiresSets { get; set; }
        public bool RequiresWeight { get; set; }
        public bool RequiresBodyweight { get; set; }
        public bool RequiresTime { get; set; }

        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //TODO: RPE CHART

        public virtual ICollection<ExerciseTypeTag> Properties { get; set; } = new HashSet<ExerciseTypeTag>();
        public virtual ICollection<ExerciseMax> ExerciseMaxes { get; set; } = new HashSet<ExerciseMax>();
        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
    }
}