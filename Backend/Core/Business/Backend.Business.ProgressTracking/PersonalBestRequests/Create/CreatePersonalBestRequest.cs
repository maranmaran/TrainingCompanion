using System;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequest : IRequest<Domain.Entities.ProgressTracking.PersonalBest>
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
