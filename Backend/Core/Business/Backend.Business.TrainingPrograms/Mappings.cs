using AutoMapper;
using Backend.Business.TrainingPrograms.BlockRequests.Create;
using Backend.Business.TrainingPrograms.BlockRequests.Update;
using Backend.Business.TrainingPrograms.DayRequests.Create;
using Backend.Business.TrainingPrograms.DayRequests.Update;
using Backend.Business.TrainingPrograms.ProgramRequests.Create;
using Backend.Business.TrainingPrograms.ProgramRequests.Update;
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
