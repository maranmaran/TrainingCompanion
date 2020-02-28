using MediatR;
using System;

namespace Backend.Application.Business.Business.Bodyweight.Create
{
    public class CreateBodyweightRequest : IRequest<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
