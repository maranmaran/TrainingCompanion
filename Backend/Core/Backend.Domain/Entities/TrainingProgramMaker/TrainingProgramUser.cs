using Backend.Domain.Entities.User;
using System;

namespace Backend.Domain.Entities.TrainingProgramMaker
{
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
}