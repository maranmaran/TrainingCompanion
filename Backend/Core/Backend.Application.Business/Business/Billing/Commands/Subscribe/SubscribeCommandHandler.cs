using AutoMapper;
using Backend.Service.Payment.Interfaces;
using Backend.Service.Payment.Models;
using MediatR;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Billing.Commands.Subscribe
{
    public class SubscribeCommandHandler : IRequestHandler<SubscribeCommand, Subscription>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public SubscribeCommandHandler(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Subscription> Handle(SubscribeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = _mapper.Map<SubscribeCommand, PaymentModel>(request);
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
