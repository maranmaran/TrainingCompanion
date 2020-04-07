using Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport;
using FluentValidation;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetMaxReport
{
    public class GetMaxReportRequestValidator : AbstractValidator<GetMaxReportRequest>
    {
        public GetMaxReportRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ExerciseTypeId).NotEmpty();
            RuleFor(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty();
        }
    }
}