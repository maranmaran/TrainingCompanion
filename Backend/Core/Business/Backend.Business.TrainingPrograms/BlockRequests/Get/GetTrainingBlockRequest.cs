using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.BlockRequests.Get
{
    public class GetTrainingBlockRequest : IRequest<TrainingBlock>
    {
        public GetTrainingBlockRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}