using MediatR;
using System;

namespace Backend.Business.TrainingLog.TrainingRequests.Get
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