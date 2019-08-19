using AutoMapper;
using Backend.Application.Business.Business.Authorization.CurrentUser;
using Backend.Application.Business.Business.Billing.AddPayment;
using Backend.Application.Business.Business.Billing.Subscribe;
using Backend.Application.Business.Business.Chat.SendChatMessage;
using Backend.Application.Business.Business.Users.CreateUser;
using Backend.Application.Business.Business.Users.UpdateUser;
using Backend.Application.Business.Extensions;
using Backend.Domain.Entities;
using Backend.Service.Chat.NgChatModels;
using Backend.Service.Payment.Models;
using System;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.User;

namespace Backend.Application.Business
{
    public class CoreMappingsProfile : Profile
    {
        public CoreMappingsProfile()
        {
            this.AuthorizationMappings();
            this.UserMappings();
            this.BillingMappings();
            this.ChatMappings();
        }

        private void AuthorizationMappings()
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

        private void UserMappings()
        {
            CreateMap<CreateUserRequest, Coach>().IgnoreAllVirtual();
            CreateMap<CreateUserRequest, Athlete>().IgnoreAllVirtual();
            CreateMap<CreateUserRequest, SoloAthlete>().IgnoreAllVirtual();

            CreateMap<UpdateUserRequest, Coach>().IgnoreAllVirtual();
            CreateMap<UpdateUserRequest, Athlete>().IgnoreAllVirtual();
            CreateMap<UpdateUserRequest, SoloAthlete>().IgnoreAllVirtual();

            CreateMap<ApplicationUser, Coach>().ReverseMap();
            CreateMap<ApplicationUser, Athlete>().ReverseMap();
            CreateMap<ApplicationUser, SoloAthlete>().ReverseMap();

        }

        private void BillingMappings()
        {
            // subscribe
            CreateMap<SubscribeRequest, PaymentModel>();
            CreateMap<AddPaymentRequest, PaymentOption>();
        }

        private void ChatMappings()
        {
            // subscribe
            CreateMap<SendChatMessageRequest, ChatMessage>();
            CreateMap<ChatMessage, MessageViewModel>()
                .ForMember(x => x.FromId, y => y.MapFrom(z => z.SenderId))
                .ForMember(x => x.ToId, y => y.MapFrom(z => z.ReceiverId))
                .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
                .ForMember(x => x.DateSent, y => y.MapFrom(z => z.SentAt))
                .ForMember(x => x.DateSeen, y => y.MapFrom(z => z.SeenAt))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.DownloadUrl, y => y.MapFrom(z => z.DownloadUrl))
                .ForMember(x => x.FileSizeInBytes, y => y.MapFrom(z => z.FileSizeInBytes));


            CreateMap<ApplicationUser, ParticipantResponseViewModel>()
                .ForMember(x => x.Participant, y => y.MapFrom(z => new ChatParticipantViewModel()
                {
                    Avatar = z.Avatar,
                    Id = z.Id.ToString(),
                    DisplayName = $"{z.FirstName} {z.LastName}",
                    Status = ChatParticipantStatus.Offline
                }))
                .ForMember(x => x.Metadata, y => y.MapFrom(z => new ParticipantMetadataViewModel()
                {
                    TotalUnreadMessages = 0,
                }));

            CreateMap<Athlete, ParticipantResponseViewModel>()
                .ForMember(x => x.Participant, y => y.MapFrom(z => new ChatParticipantViewModel()
                {
                    Avatar = z.Avatar,
                    Id = z.Id.ToString(),
                    DisplayName = $"{z.FirstName} {z.LastName}",
                    Status = ChatParticipantStatus.Offline
                }))
                .ForMember(x => x.Metadata, y => y.MapFrom(z => new ParticipantMetadataViewModel()
                {
                    TotalUnreadMessages = 0,
                }));

            CreateMap<Coach, ParticipantResponseViewModel>()
                .ForMember(x => x.Participant, y => y.MapFrom(z => new ChatParticipantViewModel()
                {
                    Avatar = z.Avatar,
                    Id = z.Id.ToString(),
                    DisplayName = $"{z.FirstName} {z.LastName}",
                    Status = ChatParticipantStatus.Offline
                }))
                .ForMember(x => x.Metadata, y => y.MapFrom(z => new ParticipantMetadataViewModel()
                {
                    TotalUnreadMessages = 0,
                }));
        }
    }
}