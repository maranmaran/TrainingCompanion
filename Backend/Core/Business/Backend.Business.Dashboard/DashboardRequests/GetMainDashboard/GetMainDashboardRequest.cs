using Backend.Domain.Entities.User.Dashboard;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Dashboard.DashboardRequests.GetMainDashboard
{
    public class GetMainDashboardRequest : IRequest<IEnumerable<Track>>
    {
        public Guid UserId { get; set; }

        public GetMainDashboardRequest(Guid id)
        {
            UserId = id;
        }
    }
}