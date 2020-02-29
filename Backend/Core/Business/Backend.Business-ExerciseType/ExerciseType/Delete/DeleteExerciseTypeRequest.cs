using System;
using MediatR;

namespace Backend.Business_ExerciseType.ExerciseType.Delete
{
    public class DeleteExerciseTypeRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}