using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.Bodyweight.GetAll
{
    public class GetAllBodyweightRequest : IRequest<IQueryable<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>>
    {
        public Guid UserId { get; set; }

    }
}
