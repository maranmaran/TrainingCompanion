using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities.User;
using MediatR;

namespace Backend.Business.Email.Requests.ResetPasswordEmail
{
    public class ResetPasswordEmailRequest : IRequest<Unit>
    {
        public ApplicationUser User { get; set; }
        public ResetPasswordEmailRequest(ApplicationUser user)
        {
            User = user;
        }
    }
}
