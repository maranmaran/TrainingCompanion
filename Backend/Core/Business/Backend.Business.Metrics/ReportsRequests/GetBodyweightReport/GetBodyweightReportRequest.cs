using MediatR;
using System;

namespace Backend.Business.Reports.ReportsRequests.GetBodyweightReport
{
    public class GetBodyweightReportRequest : IRequest<GetBodyweightReportResponse>
    {
        public Guid UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public GetBodyweightReportRequest(Guid userId, DateTime dateFrom, DateTime dateTo)
        {
            UserId = userId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
