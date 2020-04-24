using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.Exercises
{
    public class ExerciseType
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Code is mainly used for user to know identity of it's exercise type
        /// Why ? Because of imports mainly.
        /// But this is useful also internally for assigning training programs
        /// Since training programs is created with it's creators set of exercise types
        /// We will need to map that exercise to the users library the program is being assigned to
        /// However there's a catch but we need to make sure it's happening
        /// Coaches and solo athletes can only create training programs
        /// Coaches will have all changes to exercise types mapped to the athletes (this is crucial)
        /// Meaning we can use CODE to compare exercise types between accounts even if their Ids (in db) do not match
        /// </summary>
        public string Code { get; set; }

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
        public virtual ICollection<PersonalBest> PBs { get; set; } = new HashSet<PersonalBest>();
        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
    }
}