using System;
using Backend.Domain.Entities.ProgressTracking;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequest : IRequest<Domain.Entities.ProgressTracking.PersonalBest>
    {
        public CreatePersonalBestRequest(PersonalBest entity)
        {
            ExerciseTypeId = entity.ExerciseTypeId;
            Value = entity.Value;
            Date = entity.DateAchieved;
        }

        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid ExerciseTypeId { get; set; }
    }
}
