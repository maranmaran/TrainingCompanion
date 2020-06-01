using Backend.Business.Dashboard.FeedRequests.GetUserFeed;
using Backend.Business.Dashboard.Models;
using Backend.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.FeedRequests.GetGroupedUserFeed
{
    public class GetGroupedUserFeedRequest : IRequest<IEnumerable<UserActivitiesContainer>>
    {
        public GetGroupedUserFeedRequest(Guid userId, PaginationModel paginationModel = null)
        {
            UserId = userId;
            PaginationModel = paginationModel;
        }

        public Guid UserId { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }


    public class GetGroupedUserFeedRequestHandler : IRequestHandler<GetGroupedUserFeedRequest, IEnumerable<UserActivitiesContainer>>
    {
        private readonly IMediator _mediator;

        public GetGroupedUserFeedRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IEnumerable<UserActivitiesContainer>> Handle(GetGroupedUserFeedRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var activities = await _mediator.Send(new GetUserFeedRequest(request.UserId, request.PaginationModel), cancellationToken);

                // group them by userId
                var groupedActivities = activities
                    .GroupBy(x => x.UserInfo, y => y, new BasicUserInfoComparer())
                    .ToDictionary(x => x.Key, y => y)
                    .Select(x =>
                        new UserActivitiesContainer(
                            x.Key,
                            x.Value.Count(x => x.ActivityInfo.Seen == false),
                            x.Value.Select(x => x.ActivityInfo)
                        )
                    );

                return groupedActivities;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetUserFeedRequest), e);
            }
        }
    }

}
