using System;
using MediatR;

namespace Backend.Business.ProgressTracking.Bodyweight.Create
{
    public class CreateBodyweightRequest : IRequest<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
