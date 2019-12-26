using MediatR;
using System;

namespace Backend.Application.Business.Business.PushNotification.ReadNotification
{
    public class ReadNotificationRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}