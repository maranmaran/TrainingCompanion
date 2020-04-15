using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Factories
{
    public static class UserSettingsFactory
    {
        public static UserSetting GetSettings()
        {
            return new UserSetting
            {
                Id = Guid.NewGuid(),
                RpeSystem = RpeSystem.Rpe,
                Theme = Themes.Light,
            };
        }
    }
}
