using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.TagGroupRequests.Update
{
    public class UpdateTagGroupRequest : IRequest<TagGroup>
    {
        public TagGroup TagGroup { get; set; }

        public UpdateTagGroupRequest(TagGroup tagGroup)
        {
            TagGroup = tagGroup;
        }
    }
}