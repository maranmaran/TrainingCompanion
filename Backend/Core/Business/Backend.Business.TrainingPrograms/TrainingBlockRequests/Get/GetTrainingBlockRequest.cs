using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingBlockRequests.Get
{

    public class GetTrainingBlockRequest : IRequest<TrainingBlock>
    {
        public Guid Id { get; set; }
    }
}
