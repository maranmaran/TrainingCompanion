﻿using System;
using System.Collections.Generic;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

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
