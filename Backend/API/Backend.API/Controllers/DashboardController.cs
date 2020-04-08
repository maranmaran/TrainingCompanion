using Backend.Business.Dashboard.DashboardRequests.GetMainDashboard;
using Backend.Business.Dashboard.DashboardRequests.SaveMainDashboard;
using Backend.Business.Dashboard.DashboardRequests.UpdateTrackItem;
using Backend.Business.Dashboard.FeedRequests.GetUserFeed;
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
        public async Task<IActionResult> UpdateTrackItem([FromBody] UpdateTrackItemRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> SaveMainDashboard([FromBody] SaveMainDashboardRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFeed(Guid userId, CancellationToken cancellationToken = default)
        {
            //return Ok(await Cache.GetOrAddAsync($"GetFeed{userId}", entry => Mediator.Send(new GetUserFeedRequest() { UserId = userId }, cancellationToken)));

            return Ok(await Mediator.Send(new GetUserFeedRequest() { UserId = userId }, cancellationToken));
        }
    }
}
