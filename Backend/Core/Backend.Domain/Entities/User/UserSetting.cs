using Backend.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities.User
{
    public class UserSetting
    {
        public Guid Id { get; set; }
        public Themes Theme { get; set; }
        public UnitSystem UnitSystem { get; set; }
        public bool UseRpeSystem { get; set; }
        public RpeSystem RpeSystem { get; set; }
        public ICollection<NotificationSetting> NotificationSettings { get; set; }

        public Guid? MainDashboardId { get; set; }
        public virtual Dashboard.Dashboard MainDashboard { get; set; }

        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}