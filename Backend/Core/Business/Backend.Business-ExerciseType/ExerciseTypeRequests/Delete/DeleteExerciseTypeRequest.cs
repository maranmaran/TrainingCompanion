using System;
using MediatR;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Delete
{
    public class DeleteExerciseTypeRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}