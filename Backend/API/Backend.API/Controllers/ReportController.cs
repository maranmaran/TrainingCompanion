using Backend.Application.Business.Business.Reports.GetTrainingReports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{

    public class ReportController : BaseController
    {
        [HttpGet("{trainingId}")]
        public async Task<IActionResult> GetTrainingMetrics(Guid trainingId)
        {
            return Ok(await Mediator.Send(new GetTrainingReportsRequest { Id = trainingId }));
        }
    }
}
