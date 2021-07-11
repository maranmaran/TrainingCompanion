using AutoMapper;
using Backend.Business.Billing.BillingRequests.AddPayment;
using Backend.Business.Billing.BillingRequests.Subscribe;
using Backend.Library.Payment.Models;

namespace Backend.Business.Billing
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<SubscribeRequest, PaymentModel>();
            CreateMap<AddPaymentRequest, PaymentOption>();
        }
    }
}