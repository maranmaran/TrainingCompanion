using System;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Coaches.GetCoach
{
    public class GetCoachRequest : IRequest<Coach>
    {
        public Guid CoachId { get; set; }

        public GetCoachRequest(Guid id)
        {
            CoachId = id;
        }
    }
}
