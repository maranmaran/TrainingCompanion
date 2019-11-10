using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.Notification;

namespace Backend.Application.Business.Business.PushNotification
{
    public interface IPushNotificationHub
    {
        Task SendNotification(Notification notification);
        Task GetHistory(IEnumerable<Notification> notifications);
    }
}