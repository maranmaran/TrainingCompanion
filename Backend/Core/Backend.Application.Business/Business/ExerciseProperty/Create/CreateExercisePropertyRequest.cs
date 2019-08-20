using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.Create
{
    public class CreateExercisePropertyRequest : IRequest<Domain.Entities.ExerciseType.ExerciseProperty>
    {
        public Guid ExercisePropertyTypeId { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}
