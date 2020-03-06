using Backend.Business.Notifications.PushNotificationRequests.GetPushNotificationHistory;
using Backend.Business.Notifications.PushNotificationRequests.SendPushNotification;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class PushNotificationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SendPushNotification([FromBody] SendPushNotificationRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{userId}/{page}/{pageSize}")]
        public async Task<IActionResult> GetPushNotificationHistory(Guid userId, int page, int pageSize)
        {
            return Ok(await Mediator.Send(new GetPushNotificationHistoryRequest(userId, page, pageSize)));
        }
    }
}