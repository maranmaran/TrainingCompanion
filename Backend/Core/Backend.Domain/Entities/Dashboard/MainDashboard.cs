using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.Dashboard
{
    public class MainDashboard
    {
        public Guid Id { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
