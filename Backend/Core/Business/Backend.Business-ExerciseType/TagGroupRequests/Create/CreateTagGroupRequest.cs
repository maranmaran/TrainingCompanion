using MediatR;
using System;

namespace Backend.Business.ExerciseType.TagGroup.Create
{
    public class CreateTagGroupRequest : IRequest<Domain.Entities.ExerciseType.TagGroup>
    {
        public CreateTagGroupRequest(Domain.Entities.ExerciseType.TagGroup tagGroup)
        {
            ApplicationUserId = tagGroup.ApplicationUserId;
            Type = tagGroup.Type;
            Active = tagGroup.Active;
            Order = tagGroup.Order;
            HexColor = tagGroup.HexColor;
        }

        public Guid ApplicationUserId { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string HexColor { get; set; }
    }
}