﻿using Backend.Service.Payment.Enums;
using MediatR;

namespace Backend.Application.Business.Business.Billing.GetSubscriptionStatus
{
    public class GetSubscriptionStatusRequest : IRequest<SubscriptionStatus>
    {
        public string Id { get; set; }

        public GetSubscriptionStatusRequest()
        {
        }

        public GetSubscriptionStatusRequest(string id)
        {
            Id = id;
        }
    }
}