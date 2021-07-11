using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.DayRequests.Get
{
    public class GetTrainingBlockDayRequest : IRequest<TrainingBlockDay>
    {
        public GetTrainingBlockDayRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}