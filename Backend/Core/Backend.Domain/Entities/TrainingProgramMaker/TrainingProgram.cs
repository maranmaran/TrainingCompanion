using Backend.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.TrainingProgramMaker
{
    public class TrainingProgram
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageFtpFilePath { get; set; }

        // has one...
        public Guid CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        // has multiple ...
        public virtual ICollection<TrainingBlock> TrainingBlocks { get; set; } = new HashSet<TrainingBlock>();

        // is assigned to multiple...
        public virtual ICollection<TrainingProgramUser> Users { get; set; }
    }
}
