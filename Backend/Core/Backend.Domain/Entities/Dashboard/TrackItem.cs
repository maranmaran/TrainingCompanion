using System;

namespace Backend.Domain.Entities
{
    public class TrackItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Component { get; set; }

        public virtual Guid TrackId { get; set; }
        public Track Track { get; set; }

        public virtual Guid? ParamsId { get; set; }
        public virtual TrackItemParams Params { get; set; }
    }
}