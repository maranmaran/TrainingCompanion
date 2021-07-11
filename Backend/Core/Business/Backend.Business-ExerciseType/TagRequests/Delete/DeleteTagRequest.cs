using MediatR;
using System;

namespace Backend.Business.Exercises.TagRequests.Delete
{
    public class DeleteTagRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}