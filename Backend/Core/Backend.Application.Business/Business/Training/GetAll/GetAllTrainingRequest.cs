using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.Training.GetAll
{
    public class GetAllTrainingRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}