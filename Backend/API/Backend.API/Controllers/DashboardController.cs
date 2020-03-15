using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Users.DashboardRequests.GetMainDashboard;
using Backend.Business.Users.DashboardRequests.SaveMainDashboard;

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
    }
}
