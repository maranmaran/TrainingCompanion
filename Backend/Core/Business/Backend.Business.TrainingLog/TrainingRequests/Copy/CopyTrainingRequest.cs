using MediatR;
using System;
using Backend.Domain.Entities.TrainingLog;

namespace Backend.Business.TrainingLog.TrainingRequests.Copy
{
    public class CopyTrainingRequest : IRequest<Training>
    {
        public Guid TrainingId { get; set; }
        public DateTime ToDate { get; set; }
    }
}
