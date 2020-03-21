using AutoMapper;
using Backend.Business.Dashboard.Models;
using Backend.Domain;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.FeedRequests.GetUserFeed
{
    public class GetUserFeedRequestHandler : IRequestHandler<GetUserFeedRequest, IEnumerable<Activity>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;

        public GetUserFeedRequestHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator,
            ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
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
                    audits.AddRange(await _context.Audits.Where(x => x.UserId == athlete.id).ToListAsync(cancellationToken));
                }


                return GetActivities(audits, user.UserSetting, athletes);
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetUserFeedRequest), e);
            }
        }

        private IEnumerable<Activity> GetActivities(IEnumerable<AuditRecord> audits, UserSetting settings, IEnumerable<(Guid id, string name)> athletes)
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
                    Message = ActivityHelper.GetPayload(audit, settings)
                };

                activities.Add(activity);
            }

            return activities;
        }
    }
}