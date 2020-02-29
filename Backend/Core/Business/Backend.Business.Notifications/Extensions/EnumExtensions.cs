using Backend.Domain.Enum;

namespace Backend.Business.Notifications.Extensions
{
    public static class EnumExtensions
    {
        public static string GetNotificationTypeTranslation(this NotificationType type) =>
            type switch
            {
                NotificationType.MediaAdded => $"added media to training",
                NotificationType.NoteAdded => $"added note to training",
                NotificationType.TrainingCreated => $"created training"
            };
    }
}