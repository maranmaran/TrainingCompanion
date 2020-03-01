using System;

namespace Backend.Domain.Entities.User.Dashboard
{
    public class TrackItemParams
    {
        public Guid Id { get; set; }
        public string JsonParams { get; set; }

        public Guid? TrackItemId { get; set; }
        public virtual TrackItem TrackItem { get; set; }
    }
}