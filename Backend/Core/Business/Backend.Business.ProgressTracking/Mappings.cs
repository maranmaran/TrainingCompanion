using AutoMapper;
using Backend.Business.ProgressTracking.BodyweightRequests.Create;
using Backend.Business.ProgressTracking.BodyweightRequests.Update;
using Backend.Business.ProgressTracking.PersonalBestRequests.Create;
using Backend.Business.ProgressTracking.PersonalBestRequests.Update;
using Backend.Domain.Entities.ProgressTracking;

namespace Backend.Business.ProgressTracking
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateBodyweightRequest, Bodyweight>();
            CreateMap<UpdateBodyweightRequest, Bodyweight>();
            CreateMap<CreatePersonalBestRequest, PersonalBest>();
            CreateMap<UpdatePersonalBestRequest, PersonalBest>();
        }
    }
}

