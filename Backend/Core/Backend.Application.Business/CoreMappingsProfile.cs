using AutoMapper;
using Backend.Application.Business.Business.Authorization.Commands.SignIn;
using Backend.Application.Business.Business.Authorization.Queries;
using Backend.Application.Business.Business.Billing.Commands.AddPayment;
using Backend.Application.Business.Business.Billing.Commands.Subscribe;
using Backend.Application.Business.Business.Subusers.Commands.Create;
using Backend.Application.Business.Business.Users.Commands.Create;
using Backend.Application.Business.Business.Users.Commands.Update;
using Backend.Application.Business.Extensions;
using Backend.Domain.Entities;
using Backend.Service.Chat.NgChatModels;
using Backend.Service.Payment.Models;
using System;
using Backend.Application.Business.Business.Chat.Commands.SendChatMessageCommand;

namespace Backend.Application.Business
{
    public class CoreMappingsProfile : Profile
    {
        public CoreMappingsProfile()
        {
            this.AuthorizationMappings();
            this.UserMappings();
            this.SubuserMappings();
            this.BillingMappings();
            this.ChatMappings();
        }

        private void AuthorizationMappings()
        {
            CreateMap<ApplicationUser, SignInResponse>()
                .ForMember(x => x.SubscriptionStatus, o => o.Ignore())
                .ForMember(x => x.TrialDaysRemaining, opt => opt.MapFrom(user => CalculateTrial(user)));

            CreateMap<ApplicationUser, CurrentUserQueryResponse>()
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
            // create
            CreateMap<CreateUserCommand, ApplicationUser>();
            CreateMap<ApplicationUser, CreateUserResponse>();

            // update
            CreateMap<UpdateUserCommand, ApplicationUser>()
                .ForMember(x => x.CreatedOn, o => o.Ignore())
                .ForMember(x => x.AccountType, o => o.Ignore())
                .ForMember(x => x.ParentId, o => o.Ignore())
                .IgnoreAllVirtual();

        }

        private void SubuserMappings()
        {
            // create
            CreateMap<CreateSubuserCommand, ApplicationUser>()
                .ForMember(x => x.PasswordHash, o => o.Ignore());
            CreateMap<ApplicationUser, CreateSubuserResponse>();
        }

        private void BillingMappings()
        {
            // subscribe
            CreateMap<SubscribeCommand, PaymentModel>();
            CreateMap<AddPaymentCommand, PaymentModel>();
        }

        private void ChatMappings()
        {
            // subscribe
            CreateMap<SendChatMessageCommand, ChatMessage>();
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
        }
    }
}