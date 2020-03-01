using System;
using System.Linq;
using MediatR;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetAll
{
    public class GetAllBodyweightRequest : IRequest<IQueryable<Domain.Entities.ProgressTracking.Bodyweight>>
    {
        public Guid UserId { get; set; }

    }
}
