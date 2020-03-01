using System;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Delete
{
    public class DeletePersonalBestRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
