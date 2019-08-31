using Backend.Domain.Entities.ExerciseType;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.ExerciseType.Update
{
    public class UpdateExerciseTypeRequest : IRequest<Domain.Entities.ExerciseType.ExerciseType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }

        public bool? RequiresReps { get; set; }
        public bool? RequiresSets { get; set; }
        public bool? RequiresWeight { get; set; }
        public bool? RequiresBodyweight { get; set; }
        public bool? RequiresTime { get; set; }

        public IEnumerable<ExerciseTypeExerciseProperty> Properties { get; set; }
    }
}
