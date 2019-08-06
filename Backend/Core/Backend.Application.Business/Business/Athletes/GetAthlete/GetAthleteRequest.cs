using System;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Athletes.GetAthlete
{
    public class GetAthleteRequest : IRequest<Athlete>
    {
        public Guid AthleteId { get; set; }

        public GetAthleteRequest(Guid id)
        {
            AthleteId = id;
        }
    }
}
