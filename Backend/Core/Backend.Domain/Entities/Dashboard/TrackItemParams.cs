using System;

namespace Backend.Domain.Entities
{
    public class TrackItemParams
    {
        public Guid Id { get; set; }
        public string JsonParams { get; set; }

        public virtual Guid TrackItemId { get; set; }
        public TrackItem TrackItem { get; set; }
    }
}