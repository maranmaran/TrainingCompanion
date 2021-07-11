using Backend.Domain.Entities.Notification;
using MediatR;
using System;

namespace Backend.Business.Notifications.PushNotificationRequests.NotifyUser
{
    public class NotifyUserNotification : INotification
    {
        public Guid UserId { get; set; }
        public Notification Notification { get; set; }

        public NotifyUserNotification(Notification notification, Guid userId)
        {
            Notification = notification;
            UserId = userId;
        }
    }
}