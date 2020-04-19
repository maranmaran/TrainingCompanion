using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Create
{

    public class CreateTrainingProgramRequest : IRequest<TrainingProgram>
    {
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
