using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using MediatR;

namespace Backend.Business.Authorization.AuthorizationRequests.SignIn
{
    public class SignInRequest : IRequest<(CurrentUserRequestResponse response, string token)>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        //public bool RememberMe { get; set; }
    }
}