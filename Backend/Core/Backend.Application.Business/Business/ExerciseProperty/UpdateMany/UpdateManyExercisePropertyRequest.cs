using System.Collections.Generic;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateExercisePropertyRequest : IRequest<IEnumerable<Domain.Entities.ExerciseType.ExerciseProperty>>
    {
        public IEnumerable<Domain.Entities.ExerciseType.ExerciseProperty> ExerciseProperties { get; set; }
    }
}
