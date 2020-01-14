using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Track
    {
        public Guid Id { get; set; }
        public ICollection<TrackItem> Items { get; set; } = new HashSet<TrackItem>();
    }
}
