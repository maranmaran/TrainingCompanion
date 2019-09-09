using System;
using MediatR;

namespace Backend.Application.Business.Business.Set.Delete
{
    public class DeleteSetRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
