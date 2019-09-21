using System;
using MediatR;

namespace Backend.Application.Business.Business.Exercise.Get
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
