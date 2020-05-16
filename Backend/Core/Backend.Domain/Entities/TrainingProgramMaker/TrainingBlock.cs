using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.TrainingProgramMaker
{
    public class TrainingBlock
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TrainingProgramId { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }

        public BlockDurationType DurationType { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<TrainingBlockDay> Days { get; set; } = new HashSet<TrainingBlockDay>();
    }

    public enum BlockDurationType
    {
        Weeks,
        Days
    }
}