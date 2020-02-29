using MediatR;
using System;

namespace Backend.Business.ExerciseType.Tag.Delete
{
    public class DeleteTagRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}