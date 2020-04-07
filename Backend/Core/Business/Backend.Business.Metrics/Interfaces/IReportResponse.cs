using System;

namespace Backend.Business.Reports.Interfaces
{
    public interface IReportRequest
    {
        Guid UserId { get; set; }
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
    }
}