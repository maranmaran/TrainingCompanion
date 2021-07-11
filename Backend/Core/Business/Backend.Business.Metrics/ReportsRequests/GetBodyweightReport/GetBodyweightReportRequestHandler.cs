using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Reports.ReportsRequests.GetBodyweightReport
{
    public class GetBodyweightReportRequestHandler : IRequestHandler<GetBodyweightReportRequest, GetBodyweightReportResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetBodyweightReportRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetBodyweightReportResponse> Handle(GetBodyweightReportRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userSetting =
                    await _context.UserSettings.FirstOrDefaultAsync(x => x.ApplicationUserId == request.UserId,
                        cancellationToken);

                if (userSetting == null)
                    throw new Exception("User setting cannot be null");

                var unitSystem = userSetting.UnitSystem;

                var data = _context.Bodyweights
                    .OrderBy(x => x.Date.Date)
                    .Where(x => x.Date.Date >= request.DateFrom.Date &&
                                x.Date.Date <= request.DateTo.Date &&
                                x.UserId == request.UserId
                    );

                var dates = await data.Select(x => x.Date).ToListAsync(cancellationToken);
                var values = await data.Select(x => x.Value.FromMetricTo(unitSystem)).ToListAsync(cancellationToken);
                var result = new GetBodyweightReportResponse()
                {
                    Dates = dates,
                    Values = values
                };

                return result;
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetBodyweightReportRequest), e);
            }
        }
    }
}