using Backend.Business.Dashboard.Models;
using Backend.Common;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.User;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Interfaces;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.Logging.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.Services
{
    public class FeedAuditPusher : IAuditPusher
    {
        private readonly IHubContext<FeedHub, IFeedHub> _hub;
        private readonly ILoggingService _logger;
        private readonly IActivityService _activityService;
        private readonly IS3Service _s3Service;

        public FeedAuditPusher(IServiceProvider provider)
        {
            _s3Service = provider.GetService<IS3Service>();
            _activityService = provider.GetService<IActivityService>();
            _hub = provider.GetService<IHubContext<FeedHub, IFeedHub>>();
            _logger = provider.GetService<ILoggingService>();
        }

        public async Task PushToCoach(AuditRecord audit, Athlete athlete)
        {
            try
            {
                var activity = await GetActivity(audit, athlete);
                await _hub.Clients.User(athlete.CoachId.ToString()).PushFeedActivity(activity);
            }
            catch (Exception e)
            {
                await _logger.LogWarning(e,
                    $"Could not push activity to user feed. UserId: {audit.UserId} Entity: {audit.EntityType} AuditId: {audit.Id}");
            }
        }

        internal async Task<Activity> GetActivity(AuditRecord audit, ApplicationUser user)
        {
            var avatar = user.Avatar;
            if (!GenericAvatarConstructor.IsGenericAvatar(avatar) && _s3Service.CheckIfPresignedUrlIsExpired(avatar))
            {
                avatar = await _s3Service.GetPresignedUrlAsync(avatar);
            }

            var userInfo = new BasicUserInfo
            {
                UserId = audit.UserId,
                UserAvatar = avatar,
                UserName = user.FullName,
            };

            var activityInfo = new BasicActivityInfo()
            {
                Id = audit.Id,
                Date = audit.Date,
                Type = (ActivityType)Enum.Parse(typeof(ActivityType), audit.EntityType, true),
                JsonEntity = await _activityService.GetEntityAsJson(audit),
                Seen = audit.Seen
            };

            return new Activity(userInfo, activityInfo);
        }
    }
}
