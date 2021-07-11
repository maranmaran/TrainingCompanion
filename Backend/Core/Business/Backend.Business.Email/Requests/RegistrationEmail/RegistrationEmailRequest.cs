using Backend.Domain.Entities.User;
using MediatR;

namespace Backend.Business.Email.Requests.RegistrationEmail
{
    public class RegistrationEmailRequest : IRequest<Unit>
    {
        public RegistrationEmailRequest(ApplicationUser user)
        {
            User = user;
        }

        public ApplicationUser User { get; set; }
    }
}