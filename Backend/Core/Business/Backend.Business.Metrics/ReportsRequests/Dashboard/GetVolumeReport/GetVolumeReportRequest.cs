using Backend.Business.Reports.Interfaces;
using Backend.Business.Reports.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport
{

    public class GetVolumeReportRequest : IRequest<ChartData<double, DateTime>>, IReportRequest
    {
        public GetVolumeReportRequest()
        {

        }

        public GetVolumeReportRequest(Guid userId, Guid exerciseTypeId, DateTime dateFrom, DateTime dateTo)
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
        public IEnumerable<Guid> ExerciseTypeIds { get; set; }
    }
}
