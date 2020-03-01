using System;
using MediatR;

namespace Backend.Business.TrainingLog.ExerciseRequests.Get
{
    public class GetExerciseRequest : IRequest<Domain.Entities.TrainingLog.Exercise>
    {
        public Guid ExerciseId { get; set; }

        public GetExerciseRequest(Guid exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }
}