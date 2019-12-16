using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Backend.Application.Business.Business.PushNotification.ReadNotification
{
    public class ReadNotificationRequest: IRequest<Unit>
    {
        public Guid Id { get; set; }      
    }
}
