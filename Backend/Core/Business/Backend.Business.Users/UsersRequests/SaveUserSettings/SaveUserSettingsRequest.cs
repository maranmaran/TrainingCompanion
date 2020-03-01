using Backend.Domain.Entities.User;
using MediatR;

namespace Backend.Business.Users.UsersRequests.SaveUserSettings
{
    public class SaveUserSettingsRequest : IRequest<Unit>
    {
        public UserSetting UserSetting { get; set; }
    }
}