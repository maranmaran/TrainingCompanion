using Backend.Business.Authorization.AuthorizationRequests.ExternalLogin.GoogleLogin;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Authorization.AuthorizationRequests.ExternalLogin
{

    public class ExternalLoginRequest : IRequest<ExternalLoginResponse>
    {
        public AccountType AccountType { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
