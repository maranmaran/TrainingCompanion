using System;

namespace Backend.Domain.Entities.User.Dashboard
{
    public class TrackItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Component { get; set; }
        public string JsonParams { get; set; }

        public Guid TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}