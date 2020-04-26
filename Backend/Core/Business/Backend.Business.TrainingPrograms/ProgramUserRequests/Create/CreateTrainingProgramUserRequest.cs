using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Create
{

    public class CreateTrainingProgramUserRequest : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ProgramId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
