﻿using Backend.Domain.Enum;
using MediatR;
using System;

namespace Backend.Business.Notifications.PushNotificationRequests.SendPushNotification
{
    public class SendPushNotificationRequest : IRequest<Unit>
    {
        public NotificationType Type { get; set; }
        public string Payload { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}