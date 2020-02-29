using System;
using MediatR;

namespace Backend.Business_ExerciseType.Tag.Update
{
    public class UpdateTagRequest : IRequest<Domain.Entities.ExerciseType.Tag>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}