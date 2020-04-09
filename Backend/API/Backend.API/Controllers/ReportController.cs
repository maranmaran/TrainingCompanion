using Backend.Business.Reports.ReportsRequests.Dashboard.GetMaxReport;
using Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport;
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
            var key = $"Report/TrainingMetrics{userId}{trainingId}";
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
            var key = $"Report/BodyweightMetrics{userId}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo), cancellationToken));
        }

        [HttpGet("{userId}/{exerciseTypeId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetDashboardVolumeReport(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            var key = $"Report/GetDashboardVolumeReport{userId}{exerciseTypeId}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetVolumeReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetVolumeReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken));
        }

        [HttpGet("{userId}/{exerciseTypeId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetDashboardMaxReport(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            var key = $"Report/GetDashboardMaxReport{userId}{exerciseTypeId}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetMaxReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetMaxReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken));
        }
    }
}
