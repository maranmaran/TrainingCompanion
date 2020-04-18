using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Training
    {
        public Guid Id { get; set; }

        public DateTime DateTrained { get; set; }
        public string Note { get; set; }

        public bool NoteRead { get; set; }

        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Guid? TrainingBlockDayId { get; set; }
        public virtual TrainingBlockDay TrainingBlockDay { get; set; }


        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
        public virtual ICollection<MediaFile> Media { get; set; } = new HashSet<MediaFile>();
    }
}