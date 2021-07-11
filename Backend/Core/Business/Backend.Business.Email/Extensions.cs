using Backend.Domain.Enum;
using System;

namespace Backend.Business.Email
{
    public static class Extensions
    {
        public static string GetNotificationTypeTranslation(this NotificationType type) =>
            type switch
            {
                NotificationType.MediaAdded => $"added media to training",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
    }
}