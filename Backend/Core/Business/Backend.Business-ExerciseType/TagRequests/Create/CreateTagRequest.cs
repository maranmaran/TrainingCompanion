using MediatR;
using System;

namespace Backend.Business.ExerciseType.Tag.Create
{
    public class CreateTagRequest : IRequest<Domain.Entities.ExerciseType.Tag>
    {
        public Guid TagGroupId { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}