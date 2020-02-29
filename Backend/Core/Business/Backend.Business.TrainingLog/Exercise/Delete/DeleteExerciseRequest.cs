using System;
using MediatR;

namespace Backend.Business.TrainingLog.Exercise.Delete
{
    public class DeleteExerciseRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}