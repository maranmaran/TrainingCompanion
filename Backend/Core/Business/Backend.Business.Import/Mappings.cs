using AutoMapper;
using Backend.Business.Import.Models.ExerciseType;
using Backend.Domain.Entities.ExerciseType;

namespace Backend.Business.Import
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ImportExerciseTypeDto, ExerciseType>().ReverseMap();
        }
    }
}
