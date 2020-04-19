using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingBlockRequests.Update
{

    public class UpdateTrainingBlockRequest : IRequest<TrainingBlock>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInDays { get; set; }
    }
}
