using System;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Get
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
