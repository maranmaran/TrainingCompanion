using AutoMapper;
using Backend.Business.ProgressTracking.BodyweightRequests.Create;
using Backend.Business.ProgressTracking.BodyweightRequests.Update;
using Backend.Domain.Entities.ProgressTracking;

namespace Backend.Business.ProgressTracking
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateBodyweightRequest, Bodyweight>();
            CreateMap<UpdateBodyweightRequest, Bodyweight>();
        }
    }
}

