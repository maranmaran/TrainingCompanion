using AutoMapper;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Payment.Interfaces;
using Backend.Library.Payment.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Billing.BillingRequests.AddPayment
{
    public class AddPaymentRequestHandler : IRequestHandler<AddPaymentRequest>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public AddPaymentRequestHandler(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddPaymentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var paymentOption = _mapper.Map<PaymentOption>(request);

                await _paymentService.AddPaymentOption(paymentOption);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(PaymentOption), e);
            }
        }
    }
}