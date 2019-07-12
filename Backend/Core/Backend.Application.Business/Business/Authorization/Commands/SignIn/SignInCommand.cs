using Backend.Application.Business.Business.Authorization.Queries;
using MediatR;

namespace Backend.Application.Business.Business.Authorization.Commands.SignIn
{
    public class SignInCommand : IRequest<(CurrentUserQueryResponse response, string token)>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
