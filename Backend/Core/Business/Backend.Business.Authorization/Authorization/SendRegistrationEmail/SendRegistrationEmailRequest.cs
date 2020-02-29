using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Business.Authorization.Authorization.SendRegistrationEmail
{
    public class SendRegistrationEmailRequest : IRequest<Unit>
    {
        public AccountType AccountType { get; set; }
        public Athlete Athlete { get; set; }
        public Coach Coach { get; set; }
        public SoloAthlete SoloAthlete { get; set; }

        public SendRegistrationEmailRequest(Athlete athlete)
        {
            Athlete = athlete;
            AccountType = AccountType.Athlete;
        }

        public SendRegistrationEmailRequest(Coach coach)
        {
            Coach = coach;
            AccountType = AccountType.Coach;
        }

        public SendRegistrationEmailRequest(SoloAthlete soloAthlete)
        {
            SoloAthlete = soloAthlete;
            AccountType = AccountType.SoloAthlete;
        }
    }
}