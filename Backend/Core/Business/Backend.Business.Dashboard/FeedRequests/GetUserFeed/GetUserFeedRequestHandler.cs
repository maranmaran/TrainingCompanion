using Backend.Business.Dashboard.Models;
using Backend.Domain;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Infrastructure.Interfaces;

namespace Backend.Business.Dashboard.FeedRequests.GetUserFeed
{
    public class GetUserFeedRequestHandler : IRequestHandler<GetUserFeedRequest, IEnumerable<Activity>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IActivityService _activityService;

        public GetUserFeedRequestHandler(IApplicationDbContext context, IActivityService activityService)
        {
            _context = context;
            _activityService = activityService;
        }


        public async Task<IEnumerable<Activity>> Handle(GetUserFeedRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // TODO: We can just assume this will be only available to coaches right.. unless other users are allowed to have FRIENDS!
                var user = await _context.Users.Include(x => x.UserSetting).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.UserId);

                var athletes = new List<(Guid id, string name)>();
                if (user.AccountType == AccountType.Coach)
                {
                    athletes.AddRange((await _context.Athletes
                            .Where(x => x.CoachId == request.UserId)
                            .Select(x => new { x.Id, x.FullName })
                            .ToListAsync(cancellationToken)
                        ).Select(x => (x.Id, x.FullName))
                    );
                }

                var audits = new List<AuditRecord>();
                foreach (var athlete in athletes)
                {
                    var userActivities = await _context.Audits.Where(x => x.UserId == athlete.id).ToListAsync(cancellationToken);
                    audits.AddRange(userActivities);
                }


                return await GetActivities(audits, user.UserSetting, athletes);
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetUserFeedRequest), e);
            }
        }

        private async Task<IEnumerable<Activity>> GetActivities(IEnumerable<AuditRecord> audits, UserSetting settings, IEnumerable<(Guid id, string name)> athletes)
        {
            var activities = new List<Activity>();
            foreach (var audit in audits)
            {
                var activity = new Activity()
                {
                    Date = audit.Date,
                    Type = (ActivityType)Enum.Parse(typeof(ActivityType), audit.EntityType, true),
                    UserId = audit.UserId,
                    UserName = athletes.First(x => x.id == audit.UserId).name.Trim(),
                    //Message = await _activityService.GetPayload(audit, settings),
                    JsonEntity = await _activityService.GetEntityAsJson(audit)
                };

                activities.Add(activity);
            }

            return activities.OrderByDescending(x => x.Date); // newest activity is first
        }
    }
}