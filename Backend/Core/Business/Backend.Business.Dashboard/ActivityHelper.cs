using Backend.Domain;
using Backend.Domain.Deserializators;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using System;

namespace Backend.Business.Dashboard
{
    public static class ActivityHelper
    {
        public static string GetPayload(AuditRecord audit, UserSetting settings)
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
