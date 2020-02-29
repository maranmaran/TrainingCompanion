using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Dashboard;
using Backend.Service.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Users.Dashboard.SaveMainDashboard
{
    public class SaveMainDashboardRequest : IRequest<IEnumerable<Track>>
    {
        public Guid UserId { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public SaveMainDashboardRequest(Guid userId, IEnumerable<Track> tracks)
        {
            UserId = userId;
            Tracks = tracks;
        }
    }

    public class SaveMainDashboardRequestValidator : AbstractValidator<SaveMainDashboardRequest>
    {
        public SaveMainDashboardRequestValidator()
        {
            RuleFor(x => x.Tracks)
                .NotEmpty()
                .Must((item, token) => item.Tracks.Count() <= 2);
        }
    }

    public class SaveMainDashboardRequestHandler : IRequestHandler<SaveMainDashboardRequest, IEnumerable<Track>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SaveMainDashboardRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Track>> Handle(SaveMainDashboardRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.UserSetting)
                    .ThenInclude(x => x.MainDashboard)
                    .ThenInclude(x => x.Tracks)
                    .ThenInclude(x => x.Items)
                    .ThenInclude(x => x.Params)
                    .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                if (user.UserSetting.MainDashboardId == null || user.UserSetting.MainDashboardId == Guid.Empty)
                {
                    // add
                    var newMainDashboard = new Domain.Entities.Dashboard.Dashboard
                    {
                        UserSettingId = user.UserSettingId,
                        Tracks = (ICollection<Track>)request.Tracks
                    };

                    user.UserSetting.MainDashboard = newMainDashboard;

                    _context.Dashboards.Add(newMainDashboard);
                    _context.UserSettings.Update(user.UserSetting);
                }
                else
                {
                    var updatedMainDashboard = _mapper.Map<Domain.Entities.Dashboard.Dashboard>(user.UserSetting.MainDashboard);
                    updatedMainDashboard.Tracks = (ICollection<Track>)request.Tracks;

                    // update
                    user.UserSetting.MainDashboard = updatedMainDashboard;

                    _context.Entry(user.UserSetting).State = EntityState.Modified;
                    _context.Entry(user.UserSetting.MainDashboard).State = EntityState.Modified;

                    foreach (var track in user.UserSetting.MainDashboard.Tracks)
                    {
                        if (track.Id == Guid.Empty)
                        {
                            _context.Entry(track).State = EntityState.Added;
                        }
                        else
                        {
                            _context.Entry(track).State = EntityState.Modified;
                        }

                        foreach (var item in track.Items)
                        {
                            if (item.Id == Guid.Empty)
                            {
                                _context.Entry(item).State = EntityState.Added;
                            }
                            else
                            {
                                _context.Entry(item).State = EntityState.Modified;
                            }

                            if (item.Params != null)
                            {
                                if (item.Params.Id == Guid.Empty)
                                {
                                    _context.Entry(item.Params).State = EntityState.Added;
                                }
                                else
                                {
                                    _context.Entry(item.Params).State = EntityState.Modified;
                                }
                            }

                        }
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return user.UserSetting.MainDashboard.Tracks;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(SaveMainDashboardRequest), e);
            }
        }
    }
}
