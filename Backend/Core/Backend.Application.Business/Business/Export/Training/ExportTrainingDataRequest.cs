using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Runtime.Internal;
using Backend.Application.Business.Business.PushNotification;
using Backend.Domain.Entities.Notification;
using IRequest = MediatR.IRequest;

namespace Backend.Application.Business.Business.Export.Training
{
    public class ExportTrainingDataRequest: IRequest
    {
        public Guid UserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
