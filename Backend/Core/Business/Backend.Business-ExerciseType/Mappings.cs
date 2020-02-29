using AutoMapper;
using Backend.Business.ExerciseType.ExerciseType.Create;
using Backend.Business.ExerciseType.ExerciseType.Update;
using Backend.Business.ExerciseType.TagGroup.Create;
using Backend.Business.ExerciseType.TagGroup.Update;
using Backend.Domain.Entities.ExerciseType;

namespace Backend.Business.ExerciseType
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            this.TagGroupMappings();
            this.ExerciseTypeMappings();
        }
        private void TagGroupMappings()
        {
            CreateMap<Domain.Entities.ExerciseType.TagGroup, Domain.Entities.ExerciseType.TagGroup>();
            CreateMap<CreateTagGroupRequest, Domain.Entities.ExerciseType.TagGroup>();
            CreateMap<UpdateTagGroupRequest, Domain.Entities.ExerciseType.TagGroup>();
        }

        private void ExerciseTypeMappings()
        {
            CreateMap<CreateExerciseTypeRequest, Domain.Entities.ExerciseType.ExerciseType>();
            CreateMap<UpdateExerciseTypeRequest, Domain.Entities.ExerciseType.ExerciseType>();

            CreateMap<Domain.Entities.ExerciseType.ExerciseType, Domain.Entities.ExerciseType.ExerciseType>()
                .ForMember(x => x.ApplicationUser, o => o.Ignore());

            CreateMap<ExerciseTypeTag, ExerciseTypeTag>()
                .ForMember(x => x.ExerciseType, o => o.Ignore())
                .ForMember(x => x.Tag, o => o.Ignore());
        }
    }
}
