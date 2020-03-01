using System;
using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using MediatR;

namespace Backend.Business.Authorization.AuthorizationRequests.SetPassword
{
    public class SetPasswordRequest : IRequest<(CurrentUserRequestResponse response, string token)>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}