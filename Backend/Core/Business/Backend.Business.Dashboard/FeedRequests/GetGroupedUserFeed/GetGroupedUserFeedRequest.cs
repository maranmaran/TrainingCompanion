using Backend.Business.Dashboard.Models;
using Backend.Common;
using MediatR;
using System;
using System.Collections.Generic;

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
}