using System;
using System.Collections.Generic;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.User;

namespace Backend.Domain.Entities.TrainingLog
{
    public class Training
    {
        public Guid Id { get; set; }

        public DateTime DateTrained { get; set; }
        public string Note { get; set; }

        public bool NoteRead { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
        public virtual ICollection<MediaFile> Media { get; set; } = new HashSet<MediaFile>();
    }
}
