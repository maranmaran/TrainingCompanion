using FluentValidation;
using System.Linq;

namespace Backend.Business.Dashboard.DashboardRequests.SaveMainDashboard
{
    public class SaveMainDashboardRequestValidator : AbstractValidator<SaveMainDashboardRequest>
    {
        public SaveMainDashboardRequestValidator()
        {
            RuleFor(x => x.Tracks)
                .NotEmpty()
                .Must((item, token) => item.Tracks.Count() <= 2)
                .WithErrorCode("-1")
                .WithMessage("Can't have more than 2 tracks on main dashboard.");

            RuleForEach(x => x.Tracks)
                .Must(x => x.Items.Count <= 3)
                .WithErrorCode("-2")
                .WithMessage("Can't add more then 3 items to one track.");
        }
    }
}