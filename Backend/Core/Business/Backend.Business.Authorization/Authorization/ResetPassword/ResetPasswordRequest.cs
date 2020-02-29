using MediatR;

namespace Backend.Business.Authorization.Authorization.ResetPassword
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