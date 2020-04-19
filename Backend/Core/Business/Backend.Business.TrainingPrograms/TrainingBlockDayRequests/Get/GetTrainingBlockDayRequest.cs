using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Get
{

    public class GetTrainingBlockDayRequest : IRequest<TrainingBlockDay>
    {
        public Guid Id { get; set; }
    }
}
