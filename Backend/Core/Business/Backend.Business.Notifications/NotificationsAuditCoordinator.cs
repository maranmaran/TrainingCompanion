using Backend.Business.Notifications.PushNotificationRequests.NotifyUser;
using Backend.Domain;
using Backend.Domain.Deserializators;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Notifications
{
    public class NotificationsAuditCoordinator : IAuditCoordinator
    {
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;
        public NotificationsAuditCoordinator(IServiceProvider provider)
        {
            _mediator = provider.GetService<IMediator>();
            _logger = provider.GetService<ILoggingService>();
        }

        public async Task PushToCoach(AuditRecord audit, Athlete athlete)
        {
            try
            {
                if (!athlete.CoachId.HasValue)
                    throw new Exception("Athlete must have coach");

                var receiverId = athlete.CoachId.Value;
                var notification = GetNotification(audit, athlete);

                await _mediator.Publish(new NotifyUserNotification(notification, receiverId));
            }
            catch (Exception e)
            {
                await _logger.LogWarning(e,
                    $"Could not notify user about audit record. UserId: {audit.UserId} Entity: {audit.EntityType} AuditId: {audit.Id}");
            }
        }

        internal Notification GetNotification(AuditRecord audit, Athlete athlete)
        {
            try
            {
                var notification = new Notification()
                {
                    Payload = GetPayload(audit, athlete.UserSetting),
                    SenderId = athlete.Id,
                    ReceiverId = athlete.CoachId,
                    SentAt = DateTime.Now,
                    Type = NotificationHelper.GetNotificationType(audit.EntityType),
                    Sender = athlete,
                    Receiver = athlete.Coach,
                    Read = false,

                };

                return notification;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Notification), e);
            }
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
                    return $"logged bodyweight of {audit.GetData<BodyweightDeserializer>().Entity.Value.FromMetricTo(settings.UnitSystem)} {settings.UnitSystem.GetUnitLabel()}";
                case nameof(PersonalBest):
                    return "has new PR!";
                default:
                    throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}");
            }
        }
    }
}
