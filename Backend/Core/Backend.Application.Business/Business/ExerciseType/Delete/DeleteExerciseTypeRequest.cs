using System;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseType.Delete
{
    public class DeleteExerciseTypeRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
