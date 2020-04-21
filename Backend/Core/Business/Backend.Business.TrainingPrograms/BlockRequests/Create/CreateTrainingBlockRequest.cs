using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.BlockRequests.Create
{

    public class CreateTrainingBlockRequest : IRequest<TrainingBlock>
    {
        public Guid TrainingProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInDays { get; set; }
    }
}
