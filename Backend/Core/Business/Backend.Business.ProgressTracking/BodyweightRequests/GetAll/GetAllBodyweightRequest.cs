using MediatR;
using System;
using System.Linq;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetAll
{
    public class GetAllBodyweightRequest : IRequest<IQueryable<Domain.Entities.ProgressTracking.Bodyweight>>
    {
        public GetAllBodyweightRequest(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

    }
}
