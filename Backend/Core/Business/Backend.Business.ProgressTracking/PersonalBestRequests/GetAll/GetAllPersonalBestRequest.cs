using System;
using System.Linq;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.GetAll
{
    public class GetAllPersonalBestRequest : IRequest<IQueryable<Domain.Entities.ProgressTracking.PersonalBest>>
    {
        public Guid ExerciseTypeId { get; set; }

    }
}
