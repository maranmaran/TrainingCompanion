using System.Collections.Generic;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.UpdateMany
{
    public class UpdateManyExercisePropertyTypeRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.ExercisePropertyType> ExercisePropertyTypes { get; set; }
    }
}
