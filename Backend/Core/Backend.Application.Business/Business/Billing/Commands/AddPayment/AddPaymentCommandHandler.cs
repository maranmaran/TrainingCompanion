using AutoMapper;
using Backend.Service.Payment.Interfaces;
using Backend.Service.Payment.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Billing.Commands.AddPayment
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public AddPaymentCommandHandler(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
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
