using System.Collections.Generic;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateManyExercisePropertyRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.ExerciseProperty> ExerciseProperties { get; set; }
    }
}
