using System;
using System.Linq;
using MediatR;

namespace Backend.Business.TrainingLog.Training.GetAll
{
    public class GetAllTrainingRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}