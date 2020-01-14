using System;

namespace Backend.Domain.Entities
{
    public class TrackItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Component { get; set; }
    }
}