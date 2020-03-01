using System;
using System.Collections.Generic;
using Backend.Domain.Entities.User;

namespace Backend.Domain.Entities.ExerciseType
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