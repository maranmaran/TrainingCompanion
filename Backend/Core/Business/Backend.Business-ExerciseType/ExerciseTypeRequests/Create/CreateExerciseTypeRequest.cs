using MediatR;
using System.Collections.Generic;
using Backend.Domain.Entities.ExerciseType;

namespace Backend.Business.ExerciseType.ExerciseType.Create
{
    public class CreateExerciseTypeRequest : IRequest<Domain.Entities.ExerciseType.ExerciseType>
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public bool? RequiresReps { get; set; }
        public bool? RequiresSets { get; set; }
        public bool? RequiresWeight { get; set; }
        public bool? RequiresBodyweight { get; set; }
        public bool? RequiresTime { get; set; }

        public IEnumerable<ExerciseTypeTag> Properties { get; set; }
    }
}