using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;

namespace Backend.Business.Authorization.AuthorizationRequests.ExternalLogin
{
    public class ExternalLoginResponse
    {
        public ExternalLoginResponse(string token, CurrentUserRequestResponse currentUserInformation)
        {
            Token = token;
            CurrentUserInformation = currentUserInformation;
        }

        public string Token { get; set; }
        public CurrentUserRequestResponse CurrentUserInformation { get; set; }
    }
}