using System;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Users.SaveUserSettings
{
    public class SaveUserSettingsRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UserSettings UserSettings { get; set; }
    }
}
