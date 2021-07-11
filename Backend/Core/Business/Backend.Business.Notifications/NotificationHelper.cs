using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Enum;
using System;

namespace Backend.Business.Notifications
{
    internal static class NotificationHelper
    {
        internal static NotificationType GetNotificationType(string entityType)
        {
            switch (entityType)
            {
                case nameof(Training):
                    return NotificationType.TrainingCreated;

                case nameof(MediaFile):
                    return NotificationType.MediaAdded;

                case nameof(Bodyweight):
                    return NotificationType.BodyweightAdded;

                case nameof(PersonalBest):
                    return NotificationType.PersonalBestAdded;

                default:
                    throw new ArgumentException(
                        $"Entity type not recognized. Couldn't get notification type. {entityType}");
            }
        }
    }
}