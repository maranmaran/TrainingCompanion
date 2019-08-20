using System;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.Delete
{
    public class DeleteExercisePropertyTypeRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
