using Backend.Domain.Entities.TrainingLog;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingLog.ExerciseRequests.GetAll
{
    public class GetAllExerciseRequest : IRequest<IEnumerable<Exercise>>
    {
        public Guid TrainingId { get; set; }
    }
}