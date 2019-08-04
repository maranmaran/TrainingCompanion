using Backend.Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.Subusers.GetAllSubusers
{
    public class GetAllSubusersRequest : IRequest<IQueryable<ApplicationUser>>
    {
        public Guid UserId { get; set; }

        public GetAllSubusersRequest()
        {
        }

        public GetAllSubusersRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
