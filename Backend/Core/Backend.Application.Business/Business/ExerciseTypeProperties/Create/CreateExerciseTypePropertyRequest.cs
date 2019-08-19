using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.Create
{
    public class CreateExerciseTypePropertyRequest : IRequest<ExerciseTypeProperty>
    {
        public ExerciseTypePropertyType Type { get; set; }
        public string Value { get; set; }
    }
}
