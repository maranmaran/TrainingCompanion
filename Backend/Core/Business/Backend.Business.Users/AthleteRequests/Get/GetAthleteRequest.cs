using Backend.Domain.Entities.User;
using MediatR;
using System;

namespace Backend.Business.Users.AthleteRequests.Get
{
    public class GetAthleteRequest : IRequest<Athlete>
    {
        public Guid UserId { get; set; }

        public GetAthleteRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}