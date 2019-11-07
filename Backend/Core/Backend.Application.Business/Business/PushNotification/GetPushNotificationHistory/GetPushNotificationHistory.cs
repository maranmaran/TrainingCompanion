using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Entities.Notification;

namespace Backend.Application.Business.Business.PushNotification.GetPushNotificationHistory
{
    public class GetPushNotificationHistoryRequest : IRequest<IQueryable<Notification>>
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetPushNotificationHistoryRequest(Guid userId, int page, int pageSize)
        {
            UserId = userId;
            Page = page;
            PageSize = pageSize;
        }
    }
}
