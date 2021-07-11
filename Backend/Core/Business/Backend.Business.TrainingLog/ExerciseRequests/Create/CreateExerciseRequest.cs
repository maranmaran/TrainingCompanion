using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingLog.ExerciseRequests.Create
{
    public class CreateExerciseRequest : IRequest<Domain.Entities.TrainingLog.Exercise>
    {
        public Guid ExerciseTypeId { get; set; }
        public Guid TrainingId { get; set; }
        public int Order { get; set; }

        public IEnumerable<Domain.Entities.TrainingLog.Set> Sets { get; set; }
    }
}