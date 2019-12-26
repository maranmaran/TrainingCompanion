using Backend.Domain.Entities.User;
using MediatR;

namespace Backend.Application.Business.Business.Users.SaveUserSettings
{
    public class SaveUserSettingsRequest : IRequest<Unit>
    {
        public UserSetting UserSetting { get; set; }
    }
}