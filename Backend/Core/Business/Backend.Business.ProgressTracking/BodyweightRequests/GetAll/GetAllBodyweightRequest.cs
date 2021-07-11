using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetAll
{
    public class GetAllBodyweightRequest : IRequest<IEnumerable<Bodyweight>>
    {
        public GetAllBodyweightRequest(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}