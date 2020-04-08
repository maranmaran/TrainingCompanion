using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Entities.User.Dashboard;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.DashboardRequests.GetMainDashboard
{
    public class GetMainDashboardRequestHandler : IRequestHandler<GetMainDashboardRequest, IEnumerable<Track>>
    {
        private readonly IApplicationDbContext _context;

        public GetMainDashboardRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Track>> Handle(GetMainDashboardRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.UserSetting)
                    .ThenInclude(x => x.MainDashboard)
                    .ThenInclude(x => x.Tracks)
                    .ThenInclude(x => x.Items)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.UserId);


                return user.UserSetting.MainDashboard?.Tracks ?? new Track[2] { new Track(), new Track() };
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(IEnumerable<Track>), e);
            }
        }
    }
}