using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingPrograms.BlockRequests.GetAll
{
    public class GetAllTrainingBlocksRequest : IRequest<IEnumerable<TrainingBlock>>
    {
        public GetAllTrainingBlocksRequest(Guid trainingProgramId)
        {
            TrainingProgramId = trainingProgramId;
        }

        public Guid TrainingProgramId { get; set; }
    }
}