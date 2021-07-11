using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities.User
{
    public class NotificationSetting
    {
        public Guid Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool ReceiveNotification { get; set; }
        public bool ReceiveMail { get; set; }

        public virtual Guid UserSettingId { get; set; }
        public virtual UserSetting UserSetting { get; set; }
    }
}