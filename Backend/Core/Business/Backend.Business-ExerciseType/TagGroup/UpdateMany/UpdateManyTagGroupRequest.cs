using System.Collections.Generic;
using MediatR;

namespace Backend.Business_ExerciseType.TagGroup.UpdateMany
{
    public class UpdateManyTagGroupRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.TagGroup> TagGroups { get; set; }
    }
}