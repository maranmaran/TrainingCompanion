using Backend.Business.Dashboard.Models;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.User;
using Backend.Domain.Interfaces;
using Backend.Library.Logging.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard
{
    public class FeedAuditPusher : IAuditPusher
    {
        private readonly IHubContext<FeedHub, IFeedHub> _hub;
        private readonly ILoggingService _logger;

        public FeedAuditPusher(IServiceProvider provider)
        {
            //var provider = services.BuildServiceProvider();
            _hub = provider.GetService<IHubContext<FeedHub, IFeedHub>>();
            _logger = provider.GetService<ILoggingService>();
        }

        public async Task PushToCoach(AuditRecord audit, Athlete athlete)
        {
            try
            {
                var activity = GetActivity(audit, athlete);
                await _hub.Clients.User(athlete.CoachId.ToString()).PushFeedActivity(activity);
            }
            catch (Exception e)
            {
                await _logger.LogWarning(e,
                    $"Could not push activity to user feed. UserId: {audit.UserId} Entity: {audit.EntityType} AuditId: {audit.Id}");
            }
        }

        internal Activity GetActivity(AuditRecord audit, ApplicationUser user)
        {
            var activity = new Activity()
            {
                Date = audit.Date,
                Type = (ActivityType)Enum.Parse(typeof(ActivityType), audit.EntityType, true),
                UserId = audit.UserId,
                UserName = user.FullName,
                Message = ActivityHelper.GetPayload(audit, user.UserSetting)
            };

            return activity;
        }
    }
}
