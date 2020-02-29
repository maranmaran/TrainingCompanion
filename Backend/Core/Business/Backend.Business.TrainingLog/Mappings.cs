using AutoMapper;
using Backend.Business.TrainingLog.Exercise.Create;
using Backend.Business.TrainingLog.Set.Create;
using Backend.Business.TrainingLog.Training.Create;
using Backend.Business.TrainingLog.Training.Update;

namespace Backend.Business.TrainingLog
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            this.TrainingMappings();
            this.ExerciseMappings();
            this.SetMappings();
        }

        private void TrainingMappings()
        {
            CreateMap<CreateTrainingRequest, Domain.Entities.TrainingLog.Training>();
            CreateMap<UpdateTrainingRequest, Domain.Entities.TrainingLog.Training>();
        }

        private void ExerciseMappings()
        {
            CreateMap<CreateExerciseRequest, Domain.Entities.TrainingLog.Exercise>();
        }

        private void SetMappings()
        {
            CreateMap<CreateSetRequest, Domain.Entities.TrainingLog.Set>();
        }

    }
}
