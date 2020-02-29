using System;
using System.Collections.Generic;
using MediatR;

namespace Backend.Business.TrainingLog.Exercise.Create
{
    public class CreateExerciseRequest : IRequest<Domain.Entities.TrainingLog.Exercise>
    {
        public Guid ExerciseTypeId { get; set; }
        public Guid TrainingId { get; set; }
        public int Order { get; set; }

        public IEnumerable<Domain.Entities.TrainingLog.Set> Sets { get; set; }
    }
}