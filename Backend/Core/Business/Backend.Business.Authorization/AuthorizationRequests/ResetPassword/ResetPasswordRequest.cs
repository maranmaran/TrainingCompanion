using MediatR;

namespace Backend.Business.Authorization.AuthorizationRequests.ResetPassword
{
    public class ResetPasswordRequest : IRequest<Unit>
    {
        public string Email { get; set; }

        public ResetPasswordRequest(string email)
        {
            Email = email;
        }
    }
}