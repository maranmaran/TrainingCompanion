using System.Threading.Tasks;
using FluentValidation;

namespace Backend.Business.Dashboard.FeedRequests.GetUserFeed
{
    public class GetUserFeedRequestValidator : AbstractValidator<GetUserFeedRequest>
    {
        public GetUserFeedRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.PaginationModel.SortDirection).MustAsync((x, token) =>
                Task.FromResult(x.ToLower() == "asc" || x.ToLower() == "desc" || string.IsNullOrWhiteSpace(x)));
            RuleFor(x => x.PaginationModel.PageSize).NotEqual(0);
        }
    }
}