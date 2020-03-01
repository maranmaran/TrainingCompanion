using System;
using MediatR;

namespace Backend.Business.Notifications.PushNotificationRequests.ReadNotification
{
    public class ReadNotificationRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}