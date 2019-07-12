using Backend.Application.Business.Business.Billing.Commands.AddPayment;
using Backend.Application.Business.Business.Billing.Commands.CancelSubscription;
using Backend.Application.Business.Business.Billing.Commands.Subscribe;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Billing.Queries.GetPlans;
using Backend.Application.Business.Business.Billing.Queries.GetSubscription;
using Backend.Application.Business.Business.Billing.Queries.GetSubscriptionStatus;

namespace Backend.API.Controllers
{
    public class BillingController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionForCustomer(string id)
        {
            return Ok(await Mediator.Send(new GetSubscriptionQuery(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailablePlans()
        {
            return Ok(await Mediator.Send(new GetPlansQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerSubscriptionStatus(string id)
        {
            return Ok(await Mediator.Send(new GetSubscriptionStatusQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentOption([FromBody] AddPaymentCommand command)
        {
            return await Create(async () => await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeCustomer([FromBody] SubscribeCommand command)
        {
            return await Create(async () => await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CancelSubscription(string id)
        {
            return await Delete(async () => await Mediator.Send(new CancelSubscriptionCommand(id)));
        }
    }
}
