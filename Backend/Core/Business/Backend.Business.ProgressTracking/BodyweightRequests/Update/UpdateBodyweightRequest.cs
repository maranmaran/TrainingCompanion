using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Update
{
    public class UpdateBodyweightRequest : IRequest<Unit>
    {
        public UpdateBodyweightRequest(Bodyweight entity)
        {
            Value = entity.Value;
            Date = entity.Date;
            Id = entity.Id;
        }

        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
