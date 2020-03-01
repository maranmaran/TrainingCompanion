using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Business.Billing.BillingRequests.AddPayment;
using Backend.Business.Billing.BillingRequests.CancelSubscription;
using Backend.Business.Billing.BillingRequests.GetPlans;
using Backend.Business.Billing.BillingRequests.GetSubscription;
using Backend.Business.Billing.BillingRequests.GetSubscriptionStatus;
using Backend.Business.Billing.BillingRequests.Subscribe;

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