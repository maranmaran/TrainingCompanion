using MediatR;
using System;

namespace Backend.Business.Dashboard.FeedRequests.ActivitySeen
{


    public class ActivitySeenRequest : IRequest<Unit>
    {
        public ActivitySeenRequest(Guid activityId)
        {
            ActivityId = activityId;
        }

        public Guid ActivityId { get; set; }
    }
}
