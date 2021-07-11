using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.DayRequests.Update
{
    public class UpdateTrainingBlockDayRequest : IRequest<TrainingBlockDay>
    {
        public Guid Id { get; set; }
        public bool RestDay { get; set; }
    }
}