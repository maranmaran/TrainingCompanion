using MediatR;
using System;

namespace Backend.Application.Business.Business.Training.GetAll
{
    public class GetTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public Guid TrainingId { get; set; }

        public GetTrainingRequest(Guid trainingId)
        {
            TrainingId = trainingId;
        }
    }
}
