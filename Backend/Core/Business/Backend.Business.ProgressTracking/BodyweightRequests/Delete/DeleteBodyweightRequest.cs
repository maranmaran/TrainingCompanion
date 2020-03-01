using MediatR;
using System;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Delete
{
    public class DeleteBodyweightRequest : IRequest<Unit>
    {
        public DeleteBodyweightRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
