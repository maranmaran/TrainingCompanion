using AutoMapper;
using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using Backend.Domain.Entities.User;
using System;

namespace Backend.Business.Authorization
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ApplicationUser, CurrentUserRequestResponse>()
                    .ForMember(x => x.SubscriptionStatus, o => o.Ignore())
                    .ForMember(x => x.TrialDaysRemaining, opt => opt.MapFrom(user => CalculateTrial(user)));
        }

        private int CalculateTrial(ApplicationUser user)
        {
            var dayDifference = DateTime.UtcNow.Date - user.CreatedOn.Date;
            if (dayDifference.Days > user.TrialDuration)
                return 0;

            return user.TrialDuration - dayDifference.Days;
        }
    }
}