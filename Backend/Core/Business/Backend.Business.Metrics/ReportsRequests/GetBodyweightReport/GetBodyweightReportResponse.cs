using System;
using System.Collections.Generic;

namespace Backend.Business.Reports.ReportsRequests.GetBodyweightReport
{
    public class GetBodyweightReportResponse
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<double> Values { get; set; }
    }
}