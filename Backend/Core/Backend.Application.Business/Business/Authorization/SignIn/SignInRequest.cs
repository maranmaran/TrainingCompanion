using Backend.Application.Business.Business.Authorization.CurrentUser;
using MediatR;

namespace Backend.Application.Business.Business.Authorization.SignIn
{
    public class SignInRequest : IRequest<(CurrentUserRequestResponse response, string token)>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
