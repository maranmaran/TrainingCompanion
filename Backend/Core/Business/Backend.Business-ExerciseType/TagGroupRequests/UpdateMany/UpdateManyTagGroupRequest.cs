using System.Collections.Generic;
using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.TagGroupRequests.UpdateMany
{
    public class UpdateManyTagGroupRequest : IRequest<Unit>
    {
        public IEnumerable<TagGroup> TagGroups { get; set; }
    }
}