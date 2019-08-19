using System.Collections.Generic;
using Backend.Domain.Entities.ExerciseType;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.UpdateMany
{
    public class UpdateExerciseTypePropertyRequest : IRequest<IEnumerable<ExerciseTypeProperty>>
    {
        public IEnumerable<ExerciseTypeProperty> ExerciseTypeProperties { get; set; }
    }
}
