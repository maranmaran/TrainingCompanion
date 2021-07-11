using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Create
{
    public class CreateBodyweightRequest : IRequest<Bodyweight>
    {
        public CreateBodyweightRequest(Bodyweight entity)
        {
            Value = entity.Value;
            Date = entity.Date;
            UserId = entity.UserId;
        }

        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}