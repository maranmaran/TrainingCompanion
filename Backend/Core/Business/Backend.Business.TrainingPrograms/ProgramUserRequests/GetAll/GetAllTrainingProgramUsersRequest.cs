using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.GetAll
{
    public class GetAllTrainingProgramUsersRequest : IRequest<IEnumerable<TrainingProgramUser>>
    {
        public Guid ProgramId { get; set; }

        public GetAllTrainingProgramUsersRequest(Guid programId)
        {
            ProgramId = programId;
        }
    }
}