using MediatR;

namespace Backend.Business.ExerciseType.TagGroup.Update
{
    public class UpdateTagGroupRequest : IRequest<Domain.Entities.ExerciseType.TagGroup>
    {
        public Domain.Entities.ExerciseType.TagGroup TagGroup { get; set; }

        public UpdateTagGroupRequest(Domain.Entities.ExerciseType.TagGroup tagGroup)
        {
            TagGroup = tagGroup;
        }
    }
}