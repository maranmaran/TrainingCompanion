using System;
using System.Collections.Generic;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.DayRequests.GetAll
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
