using FluentValidation;
using MediatR;

namespace Backend.Business.Authorization.AuthorizationRequests.ExternalLogin
{

    public class ExternalLoginRequest : IRequest<ExternalLoginResponse>
    {
        public string AuthToken { get; set; }
        public string TokenId { get; set; }
        public string UserId { get; set; }
    }
}
