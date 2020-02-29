using System;
using MediatR;

namespace Backend.Business.TrainingLog.Training.Delete
{
    public class DeleteTrainingRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}