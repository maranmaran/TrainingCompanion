using System;
using MediatR;

namespace Backend.Business.TrainingLog.ExerciseRequests.Delete
{
    public class DeleteExerciseRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}