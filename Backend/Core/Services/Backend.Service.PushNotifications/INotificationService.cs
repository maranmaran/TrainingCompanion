using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.User;

namespace Backend.Service.PushNotifications
{
    public interface INotificationService
    {
        // TODO: Implement this
        /// <summary>
        /// Notifies user by mail and push notification based on user setting
        /// </summary>
        /// <returns></returns>
        Task NotifyUser(Notification notification, IEnumerable<NotificationSetting> settings, CancellationToken cancellationToken);
    }
}