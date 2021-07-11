using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Update
{
    public class UpdatePersonalBestRequest : IRequest<Unit>
    {
        public UpdatePersonalBestRequest(PersonalBest entity)
        {
            Id = entity.Id;
            Value = entity.Value;
            Date = entity.DateAchieved;
        }

        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}