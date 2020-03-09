using System;
using FluentValidation;

namespace Backend.Business.Reports.ReportsRequests.GetBodyweightReport
{
    public class GetBodyweightReportRequestValidator : AbstractValidator<GetBodyweightReportRequest>
    {
        public GetBodyweightReportRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.DateFrom).NotEmpty().NotNull().Must(from => from <= DateTime.Today);
            RuleFor(x => x.DateTo).NotEmpty().NotNull();
        }
    }
}