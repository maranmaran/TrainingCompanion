using Backend.Business.Notifications.Interfaces;
using Backend.Business.Notifications.PushNotificationRequests;
using Backend.Business.Notifications.PushNotificationRequests.NotifyUser;
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
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Notifications
{
    public class NotificationsAuditCoordinator : IAuditCoordinator
    {
        private readonly IHubContext<PushNotificationHub, IPushNotificationHub> _hub;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;
        public NotificationsAuditCoordinator(IServiceProvider provider)
        {
            //var provider = services.BuildServiceProvider();
            _hub = provider.GetService<IHubContext<PushNotificationHub, IPushNotificationHub>>();
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
                await _logger.LogError(e,
                    $"Could not notify user about audit record. UserId: {audit.UserId} Entity: {audit.EntityType} AuditId: {audit.Id}");
            }
        }

        internal Notification GetNotification(AuditRecord audit, Athlete athlete)
        {
            try
            {
                var notification = new Notification()
                {
                    Payload = GetPayload(audit.EntityType),
                    SenderId = athlete.Id,
                    ReceiverId = athlete.CoachId,
                    SentAt = DateTime.Now,
                    Type = NotificationHelper.GetNotificationType(audit.EntityType),
                };

                return notification;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Notification), e);
            }
        }

        internal string GetPayload(string entityType)
        {
            switch (entityType)
            {
                case nameof(Training):
                    return string.Empty;
                case nameof(MediaFile):
                    return string.Empty;
                case nameof(Bodyweight):
                    return string.Empty;
                case nameof(PersonalBest):
                    return string.Empty;
                default:
                    throw new ArgumentException($"Entity type is not recognized. {entityType}");
            }
        }
    }
}
