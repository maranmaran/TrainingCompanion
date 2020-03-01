using AutoMapper;
using Backend.Business.Users.UsersRequests.CreateUser;
using Backend.Business.Users.UsersRequests.UpdateUser;
using Backend.Domain.Entities.User;
using Backend.Service.Infrastructure.Extensions;

namespace Backend.Business.Users
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateUserRequest, Coach>().IgnoreAllVirtual()
                .ForMember(x => x.UserSetting, o => o.MapFrom(x => new UserSetting()));
            CreateMap<CreateUserRequest, Athlete>().IgnoreAllVirtual()
                .ForMember(x => x.UserSetting, o => o.MapFrom(x => new UserSetting()));
            CreateMap<CreateUserRequest, SoloAthlete>().IgnoreAllVirtual()
                .ForMember(x => x.UserSetting, o => o.MapFrom(x => new UserSetting()));

            CreateMap<UpdateUserRequest, Coach>().IgnoreAllVirtual();
            CreateMap<UpdateUserRequest, Athlete>().IgnoreAllVirtual();
            CreateMap<UpdateUserRequest, SoloAthlete>().IgnoreAllVirtual();

            CreateMap<ApplicationUser, Coach>().ReverseMap();
            CreateMap<ApplicationUser, Athlete>().ReverseMap();
            CreateMap<ApplicationUser, SoloAthlete>().ReverseMap();
        }
    }
}
