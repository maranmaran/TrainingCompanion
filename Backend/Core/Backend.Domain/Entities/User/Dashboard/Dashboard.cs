using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.User.Dashboard
{
    public class Dashboard
    {
        public Guid Id { get; set; }
        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public Guid UserSettingId { get; set; }
        public virtual UserSetting UserSetting { get; set; }
    }
}