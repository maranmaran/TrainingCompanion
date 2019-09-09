using Backend.Domain.Entities.TrainingLog;

namespace Backend.Application.Business.Business.Training.Update
{
    public class UpdateTrainingRequestResponse
    {
        public Domain.Entities.TrainingLog.Training Training { get; set; }
        public Domain.Entities.TrainingLog.Exercise AddedExercise { get; set; }
    }
}