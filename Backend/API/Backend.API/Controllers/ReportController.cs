using Backend.Business.Reports.ReportsRequests.GetBodyweightReport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Business.Reports.ReportsRequests.GetTrainingReports;

namespace Backend.API.Controllers
{

    public class ReportController : BaseController
    {
        [HttpGet("{trainingId}/{userId}")]
        public async Task<IActionResult> GetTrainingMetrics(Guid trainingId, Guid userId)
        {
            return Ok(await Mediator.Send(new GetTrainingReportsRequest { TrainingId = trainingId, UserId = userId }));
        }

        [HttpGet("{userId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetBodyweightReport(Guid userId, DateTime dateFrom, DateTime dateTo)
        {
            return Ok(await Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo)));
        }
    }
}
