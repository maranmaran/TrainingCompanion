using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Create
{

    public class CreateTrainingProgramUserRequest : IRequest<TrainingProgramUser>
    {
        public Guid UserId { get; set; }
        public Guid ProgramId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
