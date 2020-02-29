using Backend.Domain.Entities.User;
using MediatR;

namespace Backend.Business.Users.Users.SaveUserSettings
{
    public class SaveUserSettingsRequest : IRequest<Unit>
    {
        public UserSetting UserSetting { get; set; }
    }
}