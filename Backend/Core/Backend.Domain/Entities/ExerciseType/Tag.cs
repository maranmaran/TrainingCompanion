using System;

namespace Backend.Domain.Entities.ExerciseType
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        public virtual Guid TagGroupId { get; set; }
        public virtual TagGroup TagGroup { get; set; }
    }
}
