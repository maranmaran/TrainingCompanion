using Backend.Domain.Entities.TrainingLog;
using MediatR;
using System;

namespace Backend.Business.TrainingLog.TrainingRequests.Copy
{
    public class CopyTrainingRequest : IRequest<Training>
    {
        public Guid TrainingId { get; set; }
        public DateTime ToDate { get; set; }
        public Guid ToProgramDay { get; set; }
    }
}