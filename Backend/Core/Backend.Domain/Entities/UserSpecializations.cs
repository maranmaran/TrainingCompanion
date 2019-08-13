using Backend.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Admin : ApplicationUser
    {
        public new AccountType AccountType => AccountType.Admin;
    }

    public class Coach : ApplicationUser
    {
        public new AccountType AccountType => AccountType.Coach;

        public virtual ICollection<Athlete> Athletes { get; set; } = new HashSet<Athlete>();
    }

    public class Athlete : ApplicationUser
    {
        public new AccountType AccountType => AccountType.Athlete;

        public Guid? CoachId { get; set; }
        public virtual Coach Coach { get; set; }
    }

    public class SoloAthlete : ApplicationUser
    {
        public new AccountType AccountType => AccountType.SoloAthlete;
    }

}
