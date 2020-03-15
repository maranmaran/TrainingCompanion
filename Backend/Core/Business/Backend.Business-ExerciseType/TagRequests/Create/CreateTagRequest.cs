using System;
using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.TagRequests.Create
{
    public class CreateTagRequest : IRequest<Tag>
    {
        public Guid TagGroupId { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}