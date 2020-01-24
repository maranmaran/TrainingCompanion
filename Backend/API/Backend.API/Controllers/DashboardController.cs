using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Dashboard.GetMainDashboard;
using Backend.Application.Business.Business.Dashboard.SaveMainDashboard;

namespace Backend.API.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMainDashboard(Guid userId)
        {
            return Ok(await Mediator.Send(new GetMainDashboardRequest(userId)));
        }

        [HttpPost]
        public async Task<IActionResult> SaveMainDashboard([FromBody] SaveMainDashboardRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
