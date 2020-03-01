using System;
using System.Linq;
using MediatR;

namespace Backend.Business.TrainingLog.ExerciseRequests.GetAll
{
    public class GetAllExerciseRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Exercise>>
    {
        public Guid TrainingId { get; set; }
    }
}