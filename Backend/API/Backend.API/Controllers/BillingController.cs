using Backend.Application.Business.Business.Billing.AddPayment;
using Backend.Application.Business.Business.Billing.CancelSubscription;
using Backend.Application.Business.Business.Billing.GetPlans;
using Backend.Application.Business.Business.Billing.GetSubscription;
using Backend.Application.Business.Business.Billing.GetSubscriptionStatus;
using Backend.Application.Business.Business.Billing.Subscribe;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class BillingController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionForCustomer(string id)
        {
            return Ok(await Mediator.Send(new GetSubscriptionRequest(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailablePlans()
        {
            return Ok(await Mediator.Send(new GetPlansRequest()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerSubscriptionStatus(string id)
        {
            return Ok(await Mediator.Send(new GetSubscriptionStatusRequest(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentOption([FromBody] AddPaymentRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeCustomer([FromBody] SubscribeRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CancelSubscription(string id)
        {
            return await Delete(async () => await Mediator.Send(new CancelSubscriptionRequest(id)));
        }
    }
}
