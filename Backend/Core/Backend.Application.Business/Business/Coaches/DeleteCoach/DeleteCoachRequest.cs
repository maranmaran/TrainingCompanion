using System;
using MediatR;

namespace Backend.Application.Business.Business.Coaches.DeleteCoach
{
    public class DeleteCoachRequest : IRequest
    {
        public Guid CoachId { get; set; }

        public DeleteCoachRequest(Guid coachId)
        {
            CoachId = coachId;
        }
    }
}
