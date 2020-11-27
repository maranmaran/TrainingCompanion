using Backend.Domain.Entities.Exercises;
using MediatR;
using System;

namespace Backend.Business.Exercises.TagGroupRequests.Create
{
    public class CreateTagGroupRequest : IRequest<TagGroup>
    {
        public CreateTagGroupRequest(TagGroup tagGroup)
        {
            ApplicationUserId = tagGroup.ApplicationUserId;
            Type = tagGroup.Type;
            Active = tagGroup.Active;
            Order = tagGroup.Order;
            HexColor = tagGroup.HexColor;
            HexBackground = tagGroup.HexBackground;
        }

        public Guid ApplicationUserId { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string HexColor { get; set; }
        public string HexBackground { get; set; }
    }
}