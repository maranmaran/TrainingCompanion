using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetLatest
{
    public class GetLatestBodyweightRequest : IRequest<Bodyweight>
    {
        public GetLatestBodyweightRequest(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}