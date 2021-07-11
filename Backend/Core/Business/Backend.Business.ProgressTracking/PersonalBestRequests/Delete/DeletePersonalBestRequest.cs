using MediatR;
using System;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Delete
{
    public class DeletePersonalBestRequest : IRequest<Unit>
    {
        public DeletePersonalBestRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}