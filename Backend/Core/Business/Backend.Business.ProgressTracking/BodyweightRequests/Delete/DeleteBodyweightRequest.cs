using System;
using MediatR;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Delete
{
    public class DeleteBodyweightRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
