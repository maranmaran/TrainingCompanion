﻿using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.BlockRequests.Update
{
    public class UpdateTrainingBlockRequest : IRequest<TrainingBlock>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}