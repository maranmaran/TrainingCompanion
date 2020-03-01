using System;
using System.Collections.Generic;
using Backend.Domain.Entities.User.Dashboard;
using MediatR;

namespace Backend.Business.Users.DashboardRequests.GetMainDashboard
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
