using AutoMapper;
using Backend.Business.Notifications.PushNotificationRequests.NotifyUser;
using Backend.Common;
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
using Backend.Infrastructure.Interfaces;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Notifications
{
    public class NotificationsAuditPusher : IAuditPusher
    {
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;
        private readonly IS3Service _s3Service;

        public NotificationsAuditPusher(IServiceProvider provider)
        {
            _mediator = provider.GetService<IMediator>();
            _s3Service = provider.GetService<IS3Service>();
            _logger = provider.GetService<ILoggingService>();
            _context = provider.GetService<IApplicationDbContext>();
            _mapper = provider.GetService<IMapper>();
            _activityService = provider.GetService<IActivityService>();
        }

        public async Task PushToCoach(AuditRecord audit, Athlete athlete)
        {
            try
            {
                if (!athlete.CoachId.HasValue)
                    throw new Exception("Athlete must have coach");

                var receiverId = athlete.CoachId.Value;
                var notification = await GetNotification(audit, athlete);

                var notificationToSave = _mapper.Map<Notification>(notification);
                await _context.Notifications.AddAsync(notificationToSave);
                await _context.SaveChangesAsync();

                await _mediator.Publish(new NotifyUserNotification(notification, receiverId));
            }
            catch (Exception e)
            {
                await _logger.LogWarning(e,
                    $"Could not notify user about audit record. UserId: {audit.UserId} Entity: {audit.EntityType} AuditId: {audit.Id}");
            }
        }

        internal async Task<Notification> GetNotification(AuditRecord audit, Athlete athlete)
        {
            try
            {
                var avatar = athlete.Avatar;
                if (!GenericAvatarConstructor.IsGenericAvatar(avatar) &&
                    _s3Service.CheckIfPresignedUrlIsExpired(avatar))
                    avatar = await _s3Service.GetPresignedUrlAsync(avatar);

                var notification = new Notification()
                {
                    Payload = GetPayload(audit, athlete.UserSetting),
                    SenderId = athlete.Id,
                    SenderAvatar = avatar,
                    SystemNotification = false,
                    ReceiverId = athlete.CoachId,
                    SentAt = DateTime.Now,
                    Type = NotificationHelper.GetNotificationType(audit.EntityType),
                    Sender = athlete,
                    Receiver = athlete.Coach,
                    Read = false,
                    JsonEntity = await _activityService.GetEntityAsJson(audit)
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
                    return $"logged bodyweight of {audit.GetData<BodyweightDeserializeResult>().Entity.Value.FromMetricTo(settings.UnitSystem)} {settings.UnitSystem.GetUnitLabel()}";
                case nameof(PersonalBest):
                    return "has new PR!";
                default:
                    throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}");
            }
        }
    }
}
