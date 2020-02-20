using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;

namespace Backend.Application.Business.Factories
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
