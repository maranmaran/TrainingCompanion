using AutoMapper;
using Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Create;
using Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Update;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Create;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Update;
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

            CreateMap<CreateTrainingBlockRequest, TrainingBlock>();
            CreateMap<UpdateTrainingBlockRequest, TrainingBlock>();

            CreateMap<CreateTrainingBlockDayRequest, TrainingBlockDay>();
            CreateMap<UpdateTrainingBlockDayRequest, TrainingBlockDay>();
        }

    }
}
