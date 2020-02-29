using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Backend.Business.Billing.Billing.AddPayment;
using Backend.Business.Billing.Billing.Subscribe;
using Backend.Service.Payment.Models;

namespace Backend.Business.Billing
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<SubscribeRequest, PaymentModel>();
            CreateMap<AddPaymentRequest, PaymentOption> ();
        }
    }
}
