using Backend.Application.Business.Business.Dashboard.GetMainDashboardRequest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMainDashboard(Guid userId)
        {
            return Ok(await Mediator.Send(new GetMainDashboardRequest(userId)));
        }

    }
}
