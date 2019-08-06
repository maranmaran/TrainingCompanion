using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Coach : ApplicationUser
    {
        public virtual ICollection<Athlete> Athletes { get; set; } = new HashSet<Athlete>();
    }
}
