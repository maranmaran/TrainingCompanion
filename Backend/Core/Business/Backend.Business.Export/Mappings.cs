using AutoMapper;
using Backend.Domain.Entities.TrainingLog;
using System.Linq;

namespace Backend.Business.Export
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Training, ExportTrainingDto>()
                .ForMember(x => x.Date, y => y.MapFrom(x => x.DateTrained.Date));

            CreateMap<Exercise, ExportExerciseDto>()
                .ForMember(x => x.Exercise, y => y.MapFrom(x => x.ExerciseType.Name))
                .ForMember(x => x.ExerciseTags, y => y.MapFrom(z =>
                    string.Join(",", z.ExerciseType.Properties
                        .OrderBy(j => j.Tag.TagGroup.Order)
                        .Select(x => x.Tag.Value))
                ));

            CreateMap<Set, ExportSetDto>();
        }
    }
}