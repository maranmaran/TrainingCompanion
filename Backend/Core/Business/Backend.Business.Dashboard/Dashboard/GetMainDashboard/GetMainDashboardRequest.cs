using System;
using System.Collections.Generic;
using Backend.Domain.Entities.Dashboard;
using MediatR;

namespace Backend.Business.Dashboard.Dashboard.GetMainDashboard
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
