using MediatR;
using System;

namespace Backend.Application.Business.Business.Exercise.GetAll
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
