using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Get
{

    public class GetTrainingProgramRequest : IRequest<TrainingProgram>
    {
        public Guid Id { get; set; }
    }
}
