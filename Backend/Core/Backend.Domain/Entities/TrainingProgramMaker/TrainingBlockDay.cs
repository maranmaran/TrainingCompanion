using Backend.Domain.Entities.TrainingLog;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.TrainingProgramMaker
{
    public class TrainingBlockDay
    {
        public Guid Id { get; set; }
        public int Order { get; set; } // generated
        public bool RestDay => Trainings?.Count == 0;
        public bool Modified { get; set; }

        public Guid TrainingBlockId { get; set; }
        public virtual TrainingBlock TrainingBlock { get; set; }

        // if it's not rest day.. then it most certainly has...
        public virtual ICollection<Training> Trainings { get; set; } = new HashSet<Training>();
    }
}