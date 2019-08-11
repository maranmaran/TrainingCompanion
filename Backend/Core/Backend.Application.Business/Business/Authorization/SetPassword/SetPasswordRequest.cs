using Backend.Application.Business.Business.Authorization.CurrentUser;
using MediatR;
using System;

namespace Backend.Application.Business.Business.Authorization.SetPassword
{
    public class SetPasswordRequest : IRequest<(CurrentUserRequestResponse response, string token)>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
