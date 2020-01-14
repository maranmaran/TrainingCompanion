using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Entities.User;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Dashboard.GetMainDashboardRequest
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
                //var user = await _context.Users
                //    .Include(x => x.UserSetting)
                //    .ThenInclude(x => x.MainDashboard)
                //    .ThenInclude(x => x.Tracks)
                //    .ThenInclude(x => x.Items)
                //    .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                //if (user == null)
                //    throw new NotFoundException(nameof(ApplicationUser), request.UserId);


                //return user.UserSetting.MainDashboard.Tracks;
                return new List<Track>();
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(IEnumerable<Track>), e);
            }
        }
    }
}