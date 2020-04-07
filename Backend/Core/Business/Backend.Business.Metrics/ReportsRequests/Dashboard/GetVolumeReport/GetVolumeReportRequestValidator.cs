using Backend.Business.Reports.ReportsRequests.Dashboard.GetMaxReport;
using FluentValidation;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeReport
{
    public class GetVolumeReportRequestValidator : AbstractValidator<GetMaxReportRequest>
    {
        public GetVolumeReportRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ExerciseTypeId).NotEmpty();
            RuleFor(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty();
        }
    }
}