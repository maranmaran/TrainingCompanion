using FluentValidation;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetBaselineVolumeReport
{
    public class GetBaselineVolumeReportRequestValidator : AbstractValidator<GetBaselineVolumeReportRequest>
    {
        public GetBaselineVolumeReportRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ExerciseTypeId).NotEmpty();
            RuleFor(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty();
        }
    }
}