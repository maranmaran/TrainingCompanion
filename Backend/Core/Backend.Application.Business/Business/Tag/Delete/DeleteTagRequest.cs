using MediatR;
using System;

namespace Backend.Application.Business.Business.Tag.Delete
{
    public class DeleteTagRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}