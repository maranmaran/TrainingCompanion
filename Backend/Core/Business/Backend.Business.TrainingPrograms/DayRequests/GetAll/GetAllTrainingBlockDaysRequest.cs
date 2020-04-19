using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.GetAll
{

    public class GetAllTrainingBlockDaysRequest : IRequest<IEnumerable<TrainingBlockDay>>
    {
        public GetAllTrainingBlockDaysRequest(Guid trainingBlockId)
        {
            TrainingBlockId = trainingBlockId;
        }

        public Guid TrainingBlockId { get; set; }
    }
}
