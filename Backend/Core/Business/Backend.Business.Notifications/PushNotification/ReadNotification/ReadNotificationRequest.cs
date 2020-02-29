using System;
using MediatR;

namespace Backend.Business.Notifications.PushNotification.ReadNotification
{
    public class ReadNotificationRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}