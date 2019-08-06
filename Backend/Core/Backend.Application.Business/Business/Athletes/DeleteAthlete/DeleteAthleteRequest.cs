using System;
using MediatR;

namespace Backend.Application.Business.Business.Athletes.DeleteAthlete
{
    public class DeleteAthleteRequest : IRequest
    {
        public DeleteAthleteRequest(Guid athleteId)
        {
            AthleteId = athleteId;
        }

        public Guid AthleteId { get; set; }
    }
}
