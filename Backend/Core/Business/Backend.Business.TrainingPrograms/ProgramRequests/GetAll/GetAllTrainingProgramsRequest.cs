using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingPrograms.ProgramRequests.GetAll
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