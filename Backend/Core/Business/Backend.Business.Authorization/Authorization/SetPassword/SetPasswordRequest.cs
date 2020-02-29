using System;
using Backend.Business.Authorization.Authorization.CurrentUser;
using MediatR;

namespace Backend.Business.Authorization.Authorization.SetPassword
{
    public class SetPasswordRequest : IRequest<(CurrentUserRequestResponse response, string token)>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}