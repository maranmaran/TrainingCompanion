using System;
using System.Collections.Generic;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

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
