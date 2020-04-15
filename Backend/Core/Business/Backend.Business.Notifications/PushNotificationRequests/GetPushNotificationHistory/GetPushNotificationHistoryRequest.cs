using Backend.Domain.Entities.Notification;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Notifications.PushNotificationRequests.GetPushNotificationHistory
{
    public class GetPushNotificationHistoryRequest : IRequest<IEnumerable<Notification>>
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