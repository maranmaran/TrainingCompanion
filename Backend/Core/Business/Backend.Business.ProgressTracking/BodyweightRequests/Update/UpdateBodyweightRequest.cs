using System;
using MediatR;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Update
{
    public class UpdateBodyweightRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
