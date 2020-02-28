using MediatR;
using System;

namespace Backend.Application.Business.Business.Bodyweight.Delete
{
    public class DeleteBodyweightRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
