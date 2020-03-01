using MediatR;
using System;

namespace Backend.Business.ExerciseType.TagGroup.Delete
{
    public class DeleteTagGroupRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}