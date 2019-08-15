using Backend.Service.PushNotifications.Model;
using MediatR;
using System;

namespace Backend.Application.Business.Business.PushNotification.SendPushNotification
{
    public class SendPushNotificationRequest : IRequest<Unit>
    {
        public PushNotificationType Type { get; set; }
        public string Payload { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        //TODO: Expand this tought with some ids.. and participants messages etc..
        //Types... someone added new training (who, profile picture, click on message leads to impersonification of profile and viewing of training
    }
}
