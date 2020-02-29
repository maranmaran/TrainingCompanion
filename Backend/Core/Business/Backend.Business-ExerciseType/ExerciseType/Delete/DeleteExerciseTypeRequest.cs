using MediatR;
using System;

namespace Backend.Business.ExerciseType.ExerciseType.Delete
{
    public class DeleteExerciseTypeRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}