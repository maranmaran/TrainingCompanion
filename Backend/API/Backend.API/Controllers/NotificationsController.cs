using Backend.Service.PushNotifications;
using Backend.Service.PushNotifications.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class NotificationsController : BaseController
    {
        private IHubContext<NotificationHub, INotificationHub> _hubContext;

        public NotificationsController(IHubContext<NotificationHub, INotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationViewModel notification)
        {
            try
            {
                await _hubContext.Clients.All.BroadcastMessage(notification.Type, notification.Payload);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
