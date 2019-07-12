using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Backend.Service.PushNotifications
{

    public interface INotificationHub
    {
        Task BroadcastMessage(string type, string payload);
    }
    public class NotificationHub : Hub<INotificationHub>
    {
        
    }
}
