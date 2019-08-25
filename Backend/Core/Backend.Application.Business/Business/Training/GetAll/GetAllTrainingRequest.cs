using System;
using System.Linq;
using MediatR;

namespace Backend.Application.Business.Business.Training.GetAll
{
    public class GetAllTrainingRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        public Guid UserId { get; set; }
    }
}
