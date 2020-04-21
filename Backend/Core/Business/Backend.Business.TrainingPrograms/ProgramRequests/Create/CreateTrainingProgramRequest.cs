using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Create
{

    public class CreateTrainingProgramRequest : IRequest<TrainingProgram>
    {
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
