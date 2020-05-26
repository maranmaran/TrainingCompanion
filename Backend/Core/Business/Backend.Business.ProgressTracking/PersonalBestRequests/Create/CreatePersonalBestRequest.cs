using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequest : IRequest<Domain.Entities.ProgressTracking.PersonalBest>
    {
        public CreatePersonalBestRequest(PersonalBest entity)
        {
            ExerciseTypeId = entity.ExerciseTypeId;
            Value = entity.Value;
            DateAchieved = entity.DateAchieved;
            Reps = entity.Reps ?? 1;
        }

        public double Reps { get; set; }
        public double Value { get; set; }
        public DateTime DateAchieved { get; set; }
        public Guid ExerciseTypeId { get; set; }
    }
}
