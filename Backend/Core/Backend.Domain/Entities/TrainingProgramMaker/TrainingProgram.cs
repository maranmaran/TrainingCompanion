using Backend.Domain.Entities.TrainingLog;
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


    // one user has multiple programs assigned
    // and one program can be assigned to multiple users
    public class TrainingProgramUser
    {
        public Guid Id { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public bool IsActive => !EndedOn.HasValue;

        public Guid TrainingProgramId { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }

        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }


    public class TrainingBlock
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TrainingProgramId { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }


        public int DurationInDays { get; set; }
        public virtual ICollection<TrainingBlockDay> Days { get; set; } = new HashSet<TrainingBlockDay>();
    }


    public class TrainingBlockDay
    {
        public Guid Id { get; set; }
        public bool RestDay { get; set; }

        public Guid TrainingBlockId { get; set; }
        public virtual TrainingBlock TrainingBlock { get; set; }

        // if it's not rest day.. then it most certainly has...
        public virtual ICollection<Training> Trainings { get; set; }
    }

}
