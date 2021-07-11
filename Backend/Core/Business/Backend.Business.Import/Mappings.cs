using AutoMapper;
using Backend.Domain.Entities.Exercises;

namespace Backend.Business.Import
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ExerciseTypeImportDto, ExerciseType>().ReverseMap();
        }
    }
}