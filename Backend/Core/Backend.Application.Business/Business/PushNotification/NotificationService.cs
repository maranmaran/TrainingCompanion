using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.User;

namespace Backend.Application.Business.Business.PushNotification
{
    public class NotificationService: INotificationService
    {
        public Task NotifyUser(Notification notification, UserSetting setting, CancellationToken cancellationToken)
        {
            switch (notification.Type)
            {
                
            }

            return Task.FromCanceled(cancellationToken);
        }
    }
}
