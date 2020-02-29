using System;
using MediatR;

namespace Backend.Business_ExerciseType.TagGroup.Delete
{
    public class DeleteTagGroupRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}