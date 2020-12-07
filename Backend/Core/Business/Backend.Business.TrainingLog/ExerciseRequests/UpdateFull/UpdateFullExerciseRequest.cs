using Backend.Domain.Entities.TrainingLog;
using MediatR;

namespace Backend.Business.TrainingLog.ExerciseRequests.UpdateFull
{
    public class UpdateFullExerciseRequest : IRequest<Exercise>
    {
        public UpdateFullExerciseRequest(Exercise exercise)
        {
            Exercise = exercise;
        }

        public Exercise Exercise { get; set; }
    }
}
