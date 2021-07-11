using MediatR;
using System;

namespace Backend.Business.Dashboard.FeedRequests.ActivitySeen
{
    public class ActivitySeenRequest : IRequest<Unit>
    {
        public ActivitySeenRequest(Guid userId, Guid activityId)
        {
            ActivityId = activityId;
            UserId = userId;
        }

        public Guid ActivityId { get; set; }
        public Guid UserId { get; set; }
    }
}