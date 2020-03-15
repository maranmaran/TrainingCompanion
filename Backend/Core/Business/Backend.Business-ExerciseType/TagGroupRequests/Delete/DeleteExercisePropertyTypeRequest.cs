using System;
using MediatR;

namespace Backend.Business.Exercises.TagGroupRequests.Delete
{
    public class DeleteTagGroupRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}