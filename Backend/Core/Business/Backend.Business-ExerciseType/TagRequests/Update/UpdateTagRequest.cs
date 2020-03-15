using System;
using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.TagRequests.Update
{
    public class UpdateTagRequest : IRequest<Tag>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}