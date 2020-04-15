using Backend.Domain.Entities.Exercises;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Create
{
    public class CreateExerciseTypeRequest : IRequest<ExerciseType>
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public bool? RequiresReps { get; set; }
        public bool? RequiresSets { get; set; }
        public bool? RequiresWeight { get; set; }
        public bool? RequiresBodyweight { get; set; }
        public bool? RequiresTime { get; set; }

        public Guid ApplicationUserId { get; set; }

        public IEnumerable<ExerciseTypeTag> Properties { get; set; }
    }
}