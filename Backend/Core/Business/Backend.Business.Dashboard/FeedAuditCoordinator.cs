using Backend.Business.Dashboard.Models;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard
{
    public class FeedAuditCoordinator : IAuditCoordinator
    {
        private readonly IHubContext<FeedHub, IFeedHub> _hub;
        private readonly IMediator _mediator;
        public FeedAuditCoordinator(IServiceCollection services, IMediator mediator)
        {
            var provider = services.BuildServiceProvider();
            _hub = provider.GetService<IHubContext<FeedHub, IFeedHub>>();
            _mediator = mediator;

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
                Message = GetPayload(audit.EntityType)
            };

            return activity;
        }


        internal string GetPayload(string entityType)
        {
            switch (entityType)
            {
                case nameof(Training):
                    return "added new training";
                case nameof(MediaFile):
                    return "attache new media";
                case nameof(Bodyweight):
                    return "logged bodyweight";
                case nameof(PersonalBest):
                    return "has new PR!";
                default:
                    throw new ArgumentException($"Entity type is not recognized. {entityType}");
            }
        }
    }
}
