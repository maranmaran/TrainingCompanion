using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.BlockRequests.Create
{

    public class CreateTrainingBlockRequest : IRequest<TrainingBlock>
    {
        public Guid TrainingProgramId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BlockDurationType DurationType { get; set; }
        public int Duration { get; set; }
    }
}
