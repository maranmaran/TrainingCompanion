using Backend.Business.Dashboard.Models;
using Backend.Common;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Dashboard.FeedRequests.GetUserFeed
{
    public class GetUserFeedRequest : IRequest<IEnumerable<Activity>>
    {
        public GetUserFeedRequest(Guid userId, PaginationModel paginationModel = null)
        {
            UserId = userId;
            PaginationModel = paginationModel;
        }

        public Guid UserId { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }
}