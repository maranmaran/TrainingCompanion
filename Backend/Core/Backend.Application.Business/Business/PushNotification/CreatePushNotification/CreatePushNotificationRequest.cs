using Backend.Domain.Entities.Notification;
using Backend.Domain.Enum;
using MediatR;
using System;

namespace Backend.Application.Business.Business.PushNotification.CreatePushNotification
{
    public class CreatePushNotificationRequest : IRequest<Notification>
    {
        public NotificationType Type { get; set; }
        public string Payload { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }

        public CreatePushNotificationRequest()
        {
        }

        public CreatePushNotificationRequest(NotificationType type, string payload, Guid senderId, Guid receiverId)
        {
            this.Type = type;
            this.Payload = payload;
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
        }
    }
}