using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;
using System.Linq;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.GetAll
{
    public class GetAllPersonalBestRequest : IRequest<IQueryable<PersonalBest>>
    {
        public GetAllPersonalBestRequest(Guid exerciseTypeId)
        {
            ExerciseTypeId = exerciseTypeId;
        }

        public Guid ExerciseTypeId { get; set; }

    }
}
