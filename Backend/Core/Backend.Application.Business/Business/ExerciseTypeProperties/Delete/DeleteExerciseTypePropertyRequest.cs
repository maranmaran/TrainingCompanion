using MediatR;
using System;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.Delete
{
    public class DeleteExerciseTypePropertyRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
