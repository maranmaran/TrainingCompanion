using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Entities.Notification;

namespace Backend.Service.PushNotifications
{
    public interface IPushNotificationHub
    {
        Task SendNotification(Notification notification);
        Task GetHistory(IEnumerable<Notification> notifications);
    }
}