using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
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

                var unitSystem = userSetting.UnitSystem; //TODO do something..

                var data = _context.Bodyweights.Where(x => x.Date >= request.DateFrom && x.Date <= request.DateTo);

                var dates = await data.Select(x => x.Date).ToListAsync(cancellationToken);
                var values = await data.Select(x => x.Value).ToListAsync(cancellationToken);
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