using MediatR;
using System;

namespace Backend.Application.Business.Business.Training.Create
{
    public class CreateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public DateTime DateTrained { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}