using Amazon.Runtime.Internal;
using Backend.Domain.Entities.TrainingLog;
using MediatR;

namespace Backend.Business.TrainingLog.ExerciseRequests.CreateFull
{
    public class CreateFullExerciseRequest: IRequest<Exercise>
    {
        public CreateFullExerciseRequest(Exercise exercise)
        {
            Exercise = exercise;
        }

        public Exercise Exercise { get; set; }
    }
}
