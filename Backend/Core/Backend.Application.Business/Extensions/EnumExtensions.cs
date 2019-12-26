using Backend.Domain.Enum;

namespace Backend.Application.Business.Extensions
{
    public static class EnumExtensions
    {
        public static string GetNotificationTypeTranslation(this NotificationType type) =>
#pragma warning disable 8509
            type switch
#pragma warning restore 8509
            {
                NotificationType.MediaAdded => $"added media to training",
                NotificationType.NoteAdded => $"added note to training",
                NotificationType.TrainingCreated => $"created training"
            };
    }
}