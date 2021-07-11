using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.GetAll
{
    public class GetAllPersonalBestRequest : IRequest<IEnumerable<PersonalBest>>
    {
        public GetAllPersonalBestRequest(Guid exerciseTypeId, int? lowerRepRange, int? upperRepRange)
        {
            ExerciseTypeId = exerciseTypeId;
            LowerRepRange = lowerRepRange ?? 1;
            UpperRepRange = upperRepRange ?? 1;
        }

        public Guid ExerciseTypeId { get; set; }
        public int? LowerRepRange { get; set; }
        public int? UpperRepRange { get; set; }
    }
}