﻿using Backend.Business.Reports.ReportsRequests.Dashboard.GetBaselineVolumeWithRelativeIntensityReport;
using Backend.Business.Reports.ReportsRequests.Dashboard.GetMaxReport;
using Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport;
using Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeWithAvgIntensityReport;
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
            var key = $"Report/BodyweightMetrics{userId}{dateFrom}{dateTo}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetBodyweightReportRequest(userId, dateFrom, dateTo), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetDashboardVolumeReport(GetVolumeReportRequest request, CancellationToken cancellationToken = default)
        {
            var key = $"Report/GetDashboardVolumeReport{request.UserId}{request.DateFrom}{request.DateTo}{string.Join(string.Empty, request.ExerciseTypeIds)}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(request, cancellationToken)
            ));

            //return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetDashboardMaxReport(GetMaxReportRequest request, CancellationToken cancellationToken = default)
        {
            var key = $"Report/GetDashboardMaxReport{request.UserId}{request.DateFrom}{request.DateTo}{string.Join(string.Empty, request.ExerciseTypeIds)}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(request, cancellationToken)
            ));
            //return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet("{userId}/{exerciseTypeId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetBaselineVolumeWithRelativeIntensityReport(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            var key = $"Report/GetBaselineVolumeWithRelativeIntensityReport{userId}{exerciseTypeId}{dateFrom}{dateTo}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetBaselineVolumeWithRelativeIntensityReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetVolumeReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken));
        }

        [HttpGet("{userId}/{exerciseTypeId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetVolumeWithAvgIntensityReport(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            var key = $"Report/GetVolumeWithAvgIntensityReport{userId}{exerciseTypeId}{dateFrom}{dateTo}";
            AddCacheKey(key);

            return Ok(await Cache.GetOrAddAsync(
                key,
                entry => Mediator.Send(new GetVolumeWithAvgIntensityReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken)
            ));

            //return Ok(await Mediator.Send(new GetVolumeReportRequest(userId, exerciseTypeId, dateFrom, dateTo), cancellationToken));
        }
    }
}