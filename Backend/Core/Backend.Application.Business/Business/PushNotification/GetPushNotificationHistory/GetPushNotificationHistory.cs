using MediatR;
using System;

namespace Backend.Application.Business.Business.PushNotification.GetPushNotificationHistory
{
    public class GetPushNotificationHistoryRequest : IRequest<Unit>
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
