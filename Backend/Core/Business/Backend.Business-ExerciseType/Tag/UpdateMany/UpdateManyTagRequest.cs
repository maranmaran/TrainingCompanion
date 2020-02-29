using System.Collections.Generic;
using MediatR;

namespace Backend.Business_ExerciseType.Tag.UpdateMany
{
    public class UpdateManyTagRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.Tag> ExerciseProperties { get; set; }
    }
}