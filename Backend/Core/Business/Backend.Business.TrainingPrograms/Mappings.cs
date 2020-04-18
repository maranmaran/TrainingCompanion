using AutoMapper;
using Backend.Business.TrainingPrograms.TrainingProgramRequests.Create;
using Backend.Business.TrainingPrograms.TrainingProgramRequests.Update;
using Backend.Domain.Entities.TrainingProgramMaker;

namespace Backend.Business.TrainingPrograms
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateTrainingProgramRequest, TrainingProgram>();
            CreateMap<UpdateTrainingProgramRequest, TrainingProgram>();
        }

    }
}
