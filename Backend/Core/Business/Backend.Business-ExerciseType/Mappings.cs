using AutoMapper;
using Backend.Business.Exercises.ExerciseTypeRequests.Create;
using Backend.Business.Exercises.ExerciseTypeRequests.Update;
using Backend.Business.Exercises.TagGroupRequests.Create;
using Backend.Business.Exercises.TagGroupRequests.Update;
using Backend.Domain.Entities.Exercises;

namespace Backend.Business.Exercises
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
            CreateMap<TagGroup, TagGroup>();
            CreateMap<CreateTagGroupRequest, TagGroup>();
            CreateMap<UpdateTagGroupRequest, TagGroup>();
        }

        private void ExerciseTypeMappings()
        {
            CreateMap<CreateExerciseTypeRequest, ExerciseType>();
            CreateMap<UpdateExerciseTypeRequest, ExerciseType>();

            CreateMap<ExerciseType, ExerciseType>()
                .ForMember(x => x.ApplicationUser, o => o.Ignore());

            CreateMap<ExerciseTypeTag, ExerciseTypeTag>()
                .ForMember(x => x.ExerciseType, o => o.Ignore())
                .ForMember(x => x.Tag, o => o.Ignore());
        }
    }
}
