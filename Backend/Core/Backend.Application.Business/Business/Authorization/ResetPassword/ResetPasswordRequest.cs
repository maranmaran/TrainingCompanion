using MediatR;
using System;

namespace Backend.Application.Business.Business.Authorization.ResetPassword
{
    public class ResetPasswordRequest : IRequest<Unit>
    {
        public Guid UserId { get; set; }

        public ResetPasswordRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
