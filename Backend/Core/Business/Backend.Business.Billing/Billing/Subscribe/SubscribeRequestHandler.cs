using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Service.Payment.Interfaces;
using Backend.Service.Payment.Models;
using MediatR;
using Stripe;

namespace Backend.Business.Billing.Billing.Subscribe
{
    public class SubscribeRequestHandler : IRequestHandler<SubscribeRequest, Subscription>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public SubscribeRequestHandler(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Subscription> Handle(SubscribeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = _mapper.Map<SubscribeRequest, PaymentModel>(request);
                var subscription = await _paymentService.AddSubscription(payment);

                return subscription;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not subscribe customer {request.CustomerId} to plan {request.PlanId}", e);
            }
        }
    }
}