using Backend.Domain;
using MediatR;
using System;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Enum;

namespace Backend.Application.Business.Business.PushNotification.SendPushNotification
{
    public class SendPushNotificationRequest : IRequest<Unit>
    {
        public NotificationType Type { get; set; }
        public string Payload { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
