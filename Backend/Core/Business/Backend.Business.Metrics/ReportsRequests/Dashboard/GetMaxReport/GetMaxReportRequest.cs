using System;
using Backend.Business.Reports.Interfaces;
using Backend.Business.Reports.Models;
using MediatR;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetMaxReport
{

    public class GetMaxReportRequest : IRequest<ChartData<double, DateTime>>, IReportRequest
    {
        public GetMaxReportRequest(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo)
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
