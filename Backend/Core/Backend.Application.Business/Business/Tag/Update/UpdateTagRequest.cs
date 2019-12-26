using MediatR;
using System;

namespace Backend.Application.Business.Business.Tag.Update
{
    public class UpdateTagRequest : IRequest<Domain.Entities.ExerciseType.Tag>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}