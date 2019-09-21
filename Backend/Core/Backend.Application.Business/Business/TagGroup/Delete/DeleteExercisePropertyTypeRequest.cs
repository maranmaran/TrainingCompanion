using MediatR;
using System;

namespace Backend.Application.Business.Business.TagGroup.Delete
{
    public class DeleteTagGroupRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
