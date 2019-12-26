using MediatR;
using System;

namespace Backend.Application.Business.Business.TagGroup.Create
{
    public class CreateTagGroupRequest : IRequest<Domain.Entities.ExerciseType.TagGroup>
    {
        public Guid ApplicationUserId { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string HexColor { get; set; }
    }
}