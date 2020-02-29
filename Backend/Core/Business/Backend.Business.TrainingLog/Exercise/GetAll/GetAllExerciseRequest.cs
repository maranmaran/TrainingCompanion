using System;
using System.Linq;
using MediatR;

namespace Backend.Business.TrainingLog.Exercise.GetAll
{
    public class GetAllExerciseRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Exercise>>
    {
        public Guid TrainingId { get; set; }
    }
}