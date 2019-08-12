using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Backend.Domain.Enum;

namespace Backend.Domain.Entities
{
    //public class Athlete : ApplicationUser
    //{
    //}

    //public class Coach : Athlete
    //{
    //    public virtual ICollection<CoachAthlete> Athletes { get; set; } = new HashSet<CoachAthlete>();
    //}

    //public class CoachAthlete : Athlete
    //{
    //    public Guid? CoachId { get; set; }
    //    public virtual Coach Coach { get; set; }
    //}

    //public class SoloAthlete : Athlete
    //{

    //}

    public class Coach : ApplicationUser
    {
        public virtual ICollection<Athlete> Athletes { get; set; } = new HashSet<Athlete>();
    }


    public class Athlete : ApplicationUser
    {
        public Guid? CoachId { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
