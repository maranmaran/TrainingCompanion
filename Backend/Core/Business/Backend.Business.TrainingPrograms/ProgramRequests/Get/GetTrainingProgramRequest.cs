﻿using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Get
{

    public class GetTrainingProgramRequest : IRequest<TrainingProgram>
    {
        public Guid Id { get; set; }

        public GetTrainingProgramRequest(Guid id)
        {
            Id = id;
        }
    }
}
