using System;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Update
{
    public class UpdatePersonalBestRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
