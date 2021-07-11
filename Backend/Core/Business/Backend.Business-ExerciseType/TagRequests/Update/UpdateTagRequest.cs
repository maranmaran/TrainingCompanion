using Backend.Domain.Entities.Exercises;
using MediatR;
using System;

namespace Backend.Business.Exercises.TagRequests.Update
{
    public class UpdateTagRequest : IRequest<Tag>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}