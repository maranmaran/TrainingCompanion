using Backend.Business.Reports.Interfaces;
using Backend.Business.Reports.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport
{
    public class GetVolumeReportRequest : IRequest<ChartData<double, DateTime>>, IReportRequest
    {
        public Guid UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public IEnumerable<Guid> ExerciseTypeIds { get; set; }
    }
}