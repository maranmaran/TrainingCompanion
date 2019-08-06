using Backend.Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.Athletes.GetAllAthletes
{
    public class GetAllAthletesRequest : IRequest<IQueryable<Athlete>>
    {
        public Guid CoachId { get; set; }

        public GetAllAthletesRequest()
        {
        }

        public GetAllAthletesRequest(Guid coachId)
        {
            CoachId = coachId;
        }
    }
}
