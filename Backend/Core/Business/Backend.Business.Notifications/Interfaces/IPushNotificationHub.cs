using Backend.Domain.Entities.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Business.Notifications.Interfaces
{
    public interface IPushNotificationHub
    {
        Task SendNotification(Notification notification);

        Task GetHistory(IEnumerable<Notification> notifications);
    }
}