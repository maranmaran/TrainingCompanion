using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Business.Metrics.Reports.GetTrainingReports;

namespace Backend.API.Controllers
{

    public class ReportController : BaseController
    {
        [HttpGet("{trainingId}/{userId}")]
        public async Task<IActionResult> GetTrainingMetrics(Guid trainingId, Guid userId)
        {
            return Ok(await Mediator.Send(new GetTrainingReportsRequest { TrainingId = trainingId, UserId = userId }));
        }
    }
}
