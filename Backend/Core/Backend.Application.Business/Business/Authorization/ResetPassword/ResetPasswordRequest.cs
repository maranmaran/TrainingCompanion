using MediatR;
using System;

namespace Backend.Application.Business.Business.Authorization.ResetPassword
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
