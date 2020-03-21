using Backend.Business.Dashboard.Models;
using Backend.Domain;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard
{
    public class FeedAuditCoordinator : IAuditCoordinator
    {
        private readonly IHubContext<FeedHub, IFeedHub> _hub;
        public FeedAuditCoordinator(IServiceProvider provider)
        {
            //var provider = services.BuildServiceProvider();
            _hub = provider.GetService<IHubContext<FeedHub, IFeedHub>>();

        }

        public async Task PushToCoach(AuditRecord audit, Athlete athlete)
        {
            var activity = GetActivity(audit, athlete);

            await _hub.Clients.User(athlete.CoachId.ToString()).PushFeedActivity(activity);
        }

        internal Activity GetActivity(AuditRecord audit, ApplicationUser user)
        {
            var activity = new Activity()
            {
                Date = audit.Date,
                Type = (ActivityType)Enum.Parse(typeof(ActivityType), audit.EntityType, true),
                UserId = audit.UserId,
                UserName = user.FullName,
                Message = GetPayload(audit, user.UserSetting)
            };

            return activity;
        }


        internal string GetPayload(AuditRecord audit, UserSetting settings)
        {
            switch (audit.EntityType)
            {
                case nameof(Training):
                    return "added new training";
                case nameof(MediaFile):
                    return "attached new media";
                case nameof(Bodyweight):
                    return $"logged bodyweight of {audit.GetData<Bodyweight>().Entity.Value.FromMetricTo(settings.UnitSystem)} {settings.UnitSystem.GetUnitLabel()}";
                case nameof(PersonalBest):
                    return "has new PR!";
                default:
                    throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}");
            }
        }
    }
}
