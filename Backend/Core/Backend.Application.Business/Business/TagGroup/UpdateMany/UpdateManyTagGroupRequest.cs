using MediatR;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.TagGroup.UpdateMany
{
    public class UpdateManyTagGroupRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.TagGroup> TagGroups { get; set; }
    }
}