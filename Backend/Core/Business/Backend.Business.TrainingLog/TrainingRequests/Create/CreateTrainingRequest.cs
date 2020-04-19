using MediatR;
using System;

namespace Backend.Business.TrainingLog.TrainingRequests.Create
{
    public class CreateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public DateTime DateTrained { get; set; }
        public Guid ApplicationUserId { get; set; }
        public Guid TrainingBlockDayId { get; set; }
    }
}