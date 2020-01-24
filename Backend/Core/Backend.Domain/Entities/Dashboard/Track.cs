using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.Dashboard
{
    public class Track
    {
        public Guid Id { get; set; }
        public virtual ICollection<TrackItem> Items { get; set; } = new HashSet<TrackItem>();

        public Guid DashboardId { get; set; }
        public virtual Entities.Dashboard.Dashboard Dashboard { get; set; }
    }
}
