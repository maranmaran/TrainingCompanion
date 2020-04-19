using Backend.Domain.Entities.TrainingProgramMaker;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.GetAll
{

    public class GetAllTrainingProgramsRequest : IRequest<IEnumerable<TrainingProgram>>
    {
        public GetAllTrainingProgramsRequest(Guid creatorId)
        {
            CreatorId = creatorId;
        }

        public Guid CreatorId { get; set; }
    }
}
