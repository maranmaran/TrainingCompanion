﻿using MediatR;

namespace Backend.Application.Business.Business.Training.Update
{
    public class UpdateTrainingRequest : IRequest<UpdateTrainingRequestResponse>
    {
        public Domain.Entities.TrainingLog.Training Training { get; set; }

        public UpdateTrainingRequest(Domain.Entities.TrainingLog.Training training)
        {
            Training = training;
        }
    }
}
