using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Update
{
    public class UpdateExerciseTypeRequest : IRequest<ExerciseType>
    {
        //public Guid Id { get; set; }
        //public string Name { get; set; }

        //public bool Active { get; set; }

        //public bool? RequiresReps { get; set; }
        //public bool? RequiresSets { get; set; }
        //public bool? RequiresWeight { get; set; }
        //public bool? RequiresBodyweight { get; set; }
        //public bool? RequiresTime { get; set; }

        //public IEnumerable<ExerciseTypeTag> Properties { get; set; }

        public ExerciseType ExerciseType { get; set; }
    }
}