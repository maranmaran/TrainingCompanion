using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Application.Business.Business.PushNotification
{
    [Authorize]
    public class PushNotificationHub : Hub
    {

    }
}
