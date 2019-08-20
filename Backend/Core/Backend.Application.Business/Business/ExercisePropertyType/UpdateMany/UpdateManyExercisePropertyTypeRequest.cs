using System.Collections.Generic;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateManyExercisePropertyTypeRequest : IRequest<IEnumerable<Domain.Entities.ExerciseType.ExercisePropertyType>>
    {
        public IEnumerable<Domain.Entities.ExerciseType.ExercisePropertyType> ExercisePropertyTypes { get; set; }
    }
}
