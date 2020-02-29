using System.Linq;
using AutoMapper;
using Backend.Business.Export.Models.Training;
using Backend.Domain.Entities.TrainingLog;
using Microsoft.EntityFrameworkCore.Internal;

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
                    z.ExerciseType.Properties
                        .OrderBy(j => j.Tag.TagGroup.Order)
                        .Select(x => x.Tag.Value).Join(" ")
                ));

            CreateMap<Set, ExportSetDto>();
        }
    }
}
