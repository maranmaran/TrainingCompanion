using Backend.Business.Reports.Interfaces;
using Backend.Business.Reports.Models;
using MediatR;
using System;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetBaselineVolumeReport
{

    public class GetBaselineVolumeReportRequest : IRequest<ChartData<double, DateTime>>, IReportRequest
    {
        public GetBaselineVolumeReportRequest(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo)
        {
            UserId = userId;
            ExerciseTypeId = exerciseTypeId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public Guid UserId { get; set; }
        public Guid ExerciseTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
