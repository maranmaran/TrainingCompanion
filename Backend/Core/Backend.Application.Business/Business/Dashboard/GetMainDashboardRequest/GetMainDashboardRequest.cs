using Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.Dashboard.GetMainDashboardRequest
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
