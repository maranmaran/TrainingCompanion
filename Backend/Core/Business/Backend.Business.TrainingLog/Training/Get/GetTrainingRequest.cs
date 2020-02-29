using System;
using MediatR;

namespace Backend.Business.TrainingLog.Training.Get
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