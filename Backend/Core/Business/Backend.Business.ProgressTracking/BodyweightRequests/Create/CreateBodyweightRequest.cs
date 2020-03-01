using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Create
{
    public class CreateBodyweightRequest : IRequest<Bodyweight>
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
