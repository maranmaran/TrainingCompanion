using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Update
{

    public class UpdateTrainingBlockDayRequest : IRequest<TrainingBlockDay>
    {
        public Guid Id { get; set; }
    }
}
