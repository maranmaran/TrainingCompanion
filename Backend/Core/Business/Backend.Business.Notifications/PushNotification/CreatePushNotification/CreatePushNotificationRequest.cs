using System;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Notifications.PushNotification.CreatePushNotification
{
    public class CreatePushNotificationRequest : IRequest<Notification>
    {
        public NotificationType Type { get; set; }
        public string Payload { get; set; }
        public Guid? SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public bool SystemNotification => !this.SenderId.HasValue;

        public CreatePushNotificationRequest()
        {
        }

        public CreatePushNotificationRequest(NotificationType type, string payload, Guid? senderId, Guid receiverId)
        {
            this.Type = type;
            this.Payload = payload;
            this.SenderId = senderId == Guid.Empty ? null : senderId;
            this.ReceiverId = receiverId;
        }

        public CreatePushNotificationRequest(NotificationType type, string payload, Guid receiverId)
        {
            this.Type = type;
            this.Payload = payload;
            this.ReceiverId = receiverId;
        }
    }
}