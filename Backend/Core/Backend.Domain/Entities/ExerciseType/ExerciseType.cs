using Backend.Domain.Entities.ProgressTracking.Max;
using Backend.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public bool? RequiresReps { get; set; }
        public bool? RequiresSets { get; set; }
        public bool? RequiresWeight { get; set; }
        public bool? RequiresBodyweight { get; set; }
        public bool? RequiresTime { get; set; }

        public Guid BarTypeId { get; set; }
        public virtual BarType BarType { get; set; }

        public Guid BarPositionId { get; set; }
        public virtual BarPosition BarPosition { get; set; }

        public Guid StanceId { get; set; }
        public virtual Stance Stance { get; set; }

        public Guid GripId { get; set; }
        public virtual Grip Grip { get; set; }

        public Guid RangeOfMotionId { get; set; }
        public virtual RangeOfMotion RangeOfMotion { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid TempoId { get; set; }
        public virtual Tempo Tempo { get; set; }

        public Guid AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }

        //TODO: RPE CHART


        public virtual ICollection<ExerciseTypeLoadAccomodation> LoadAccomodation { get; set; } = new HashSet<ExerciseTypeLoadAccomodation>();
        public virtual ICollection<ExerciseTypeEquipment> Equipment { get; set; } = new HashSet<ExerciseTypeEquipment>();
        public virtual ICollection<ExerciseMax> ExerciseMaxes { get; set; } = new HashSet<ExerciseMax>();
    }
}