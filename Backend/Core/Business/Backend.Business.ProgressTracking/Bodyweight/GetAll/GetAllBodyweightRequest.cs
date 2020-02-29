using System;
using System.Linq;
using MediatR;

namespace Backend.Business.ProgressTracking.Bodyweight.GetAll
{
    public class GetAllBodyweightRequest : IRequest<IQueryable<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>>
    {
        public Guid UserId { get; set; }

    }
}
