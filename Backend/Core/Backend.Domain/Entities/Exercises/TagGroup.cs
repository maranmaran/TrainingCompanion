using Backend.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.Exercises
{
    public class TagGroup
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string HexColor { get; set; }
        public string HexBackground { get; set; }

        public virtual Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}