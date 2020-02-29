using System;
using MediatR;

namespace Backend.Business.TrainingLog.Training.Create
{
    public class CreateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public DateTime DateTrained { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}