using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Notifications.Interfaces;
using Backend.Business.Notifications.PushNotificationRequests.CreatePushNotification;
using Backend.Business.Notifications.PushNotificationRequests.NotifyUser;
using Backend.Business.Notifications.PushNotificationRequests.ReadNotification;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Business.Notifications.PushNotificationRequests
{
    [Authorize]
    public class PushNotificationHub : Hub<IPushNotificationHub>
    {
        private readonly IMediator _mediator;

        public PushNotificationHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        // TODO:
        // CancellationToken support closed on march 31 https://github.com/aspnet/AspNetCore/issues/8813
        // Check when new version releases
        public async Task SendNotification(NotificationType type, string payload, Guid senderId, Guid receiverId)
        {
            // save to db

            var notification = await _mediator.Send(new CreatePushNotificationRequest(type, payload, senderId, receiverId), CancellationToken.None);

            await _mediator.Publish(new NotifyUserNotification(notification, notification.Receiver.UserSetting.NotificationSettings));
        }

        public async Task ReadNotification(Guid id)
        {
            await _mediator.Send(new ReadNotificationRequest() { Id = id });
        }
    }
}