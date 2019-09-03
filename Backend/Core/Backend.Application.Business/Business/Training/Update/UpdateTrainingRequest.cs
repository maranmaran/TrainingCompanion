using Backend.Domain.Entities.TrainingLog;
using MediatR;

namespace Backend.Application.Business.Business.Training.Update
{
    public class UpdateTrainingRequest : IRequest<UpdateTrainingRequestResponse>
    {
        public Domain.Entities.TrainingLog.Training Training { get; set; }
        public Exercise ExerciseAdd { get; set; }

        public UpdateTrainingRequest(Domain.Entities.TrainingLog.Training training, Exercise exercise = null)
        {
            Training = training;
            ExerciseAdd = exercise;
        }
    }
}
