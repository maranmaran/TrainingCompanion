using AutoMapper;
using Backend.Library.Logging.Interfaces;
using MediatR;
using System;
using Backend.Business.Reports.Interfaces;
using Backend.Business.Reports.Models;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport
{

    public class GetVolumeReportRequest : IRequest<ChartData<double, DateTime>>, IReportRequest
    {
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
    }
}
