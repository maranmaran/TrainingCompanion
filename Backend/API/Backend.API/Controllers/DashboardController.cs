using Backend.Business.Dashboard.FeedRequests.GetUserFeed;
using Backend.Business.Users.DashboardRequests.GetMainDashboard;
using Backend.Business.Users.DashboardRequests.SaveMainDashboard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMainDashboard(Guid userId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetMainDashboardRequest(userId), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> SaveMainDashboard([FromBody] SaveMainDashboardRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetFeed(Guid userId, CancellationToken cancellationToken = default)
        {
            return Ok(await Cache.GetOrAddAsync($"GetFeed{userId}", entry => Mediator.Send(new GetUserFeedRequest() { UserId = userId }, cancellationToken)));
        }
    }
}
