using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Service.Payment.Interfaces;
using Backend.Service.Payment.Models;
using MediatR;

namespace Backend.Application.Business.Business.Billing.AddPayment
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
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not add payment option.", ex);
            }
        }
    }
}
