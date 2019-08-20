using System;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.Delete
{
    public class DeleteExercisePropertyRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
