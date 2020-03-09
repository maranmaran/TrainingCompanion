using System;
using System.Collections.Generic;

namespace Backend.Business.Reports.ReportsRequests.GetBodyweightReport
{
    public class GetBodyweightReportResponse
    {
        public List<DateTime> Dates { get; set; }
        public List<double> Values { get; set; }
    }
}