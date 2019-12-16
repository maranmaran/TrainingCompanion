using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Business.Business.PushNotification.CreatePushNotification;
using Backend.Application.Business.Business.PushNotification.ReadNotification;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Application.Business.Business.PushNotification
{
    [Authorize]
    public class PushNotificationHub : Hub<IPushNotificationHub>
    {
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;

        public PushNotificationHub(IMediator mediator, INotificationService notificationService)
        {
            _mediator = mediator;
            _notificationService = notificationService;
        }

        // TODO:
        // CancellationToken support closed on march 31 https://github.com/aspnet/AspNetCore/issues/8813
        // Check when new version releases
        public async Task SendNotification(NotificationType type, string payload, Guid senderId, Guid receiverId)
        {

            // save to db
            var notification = await _mediator.Send(new CreatePushNotificationRequest(type, payload, senderId, receiverId), CancellationToken.None);

            await _notificationService.NotifyUser(notification, notification.Receiver.UserSetting.NotificationSettings,
                CancellationToken.None);
        }


        public async Task ReadNotification(Guid id)
        {
            await _mediator.Send(new ReadNotificationRequest() {Id = id});
        }

    }
}
