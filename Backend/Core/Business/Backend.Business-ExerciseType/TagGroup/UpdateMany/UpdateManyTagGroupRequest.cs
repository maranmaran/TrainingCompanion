using MediatR;
using System.Collections.Generic;

namespace Backend.Business.ExerciseType.TagGroup.UpdateMany
{
    public class UpdateManyTagGroupRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.TagGroup> TagGroups { get; set; }
    }
}