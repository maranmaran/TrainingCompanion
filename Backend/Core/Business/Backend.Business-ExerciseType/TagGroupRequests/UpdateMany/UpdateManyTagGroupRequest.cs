using Backend.Domain.Entities.Exercises;
using MediatR;
using System.Collections.Generic;

namespace Backend.Business.Exercises.TagGroupRequests.UpdateMany
{
    public class UpdateManyTagGroupRequest : IRequest<Unit>
    {
        public IEnumerable<TagGroup> TagGroups { get; set; }
    }
}