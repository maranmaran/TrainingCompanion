using Backend.Domain.Entities.User.Dashboard;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Dashboard.DashboardRequests.SaveMainDashboard
{
    public class SaveMainDashboardRequest : IRequest<IEnumerable<Track>>
    {
        public Guid UserId { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public SaveMainDashboardRequest(Guid userId, IEnumerable<Track> tracks)
        {
            UserId = userId;
            Tracks = tracks;
        }
    }
}
