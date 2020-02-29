using System;
using MediatR;

namespace Backend.Business_ExerciseType.Tag.Delete
{
    public class DeleteTagRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}