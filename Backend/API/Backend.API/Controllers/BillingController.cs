using System.Threading;
using Backend.Business.Billing.BillingRequests.AddPayment;
using Backend.Business.Billing.BillingRequests.CancelSubscription;
using Backend.Business.Billing.BillingRequests.GetPlans;
using Backend.Business.Billing.BillingRequests.GetSubscription;
using Backend.Business.Billing.BillingRequests.GetSubscriptionStatus;
using Backend.Business.Billing.BillingRequests.Subscribe;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class BillingController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionForCustomer(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetSubscriptionRequest(id), cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailablePlans(CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetPlansRequest(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerSubscriptionStatus(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetSubscriptionStatusRequest(id), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentOption([FromBody] AddPaymentRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeCustomer([FromBody] SubscribeRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CancelSubscription(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new CancelSubscriptionRequest(id), cancellationToken));
        }
    }
}