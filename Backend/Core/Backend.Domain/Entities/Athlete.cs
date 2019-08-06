using System;

namespace Backend.Domain.Entities
{
    public class Athlete : ApplicationUser
    {
        public Guid? CoachId { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
