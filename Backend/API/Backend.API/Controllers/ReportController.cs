using Backend.Business.Reports.ReportsRequests.GetBodyweightReport;
using Backend.Business.Reports.ReportsRequests.GetTrainingReports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{

    public class ReportController : BaseController
    {
        [HttpGet("{trainingId}/{userId}")]
        public async Task<IActionResult> GetTrainingMetrics(Guid trainingId, Guid userId, CancellationToken cancellationToken = default)
        {
            var key = $"Report/TrainingMetrics{trainingId}{userId}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetTrainingReportsRequest { TrainingId = trainingId, UserId = userId }, cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetTrainingReportsRequest { TrainingId = trainingId, UserId = userId }, cancellationToken));
        }

        [HttpGet("{userId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetBodyweightReport(Guid userId, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            var key = $"Report/BodyweightMetrics{userId}{dateFrom}{dateTo}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo), cancellationToken));
        }
    }
}
