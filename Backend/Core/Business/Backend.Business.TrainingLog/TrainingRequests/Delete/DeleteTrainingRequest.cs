using MediatR;
using System;

namespace Backend.Business.TrainingLog.TrainingRequests.Delete
{
    public class DeleteTrainingRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}