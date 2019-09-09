using System;
using MediatR;

namespace Backend.Application.Business.Business.Exercise.Delete
{
    public class DeleteExerciseRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
