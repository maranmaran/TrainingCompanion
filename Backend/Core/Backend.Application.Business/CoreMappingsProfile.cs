using AutoMapper;
using Backend.Application.Business.Business.Authorization.CurrentUser;
using Backend.Application.Business.Business.Billing.AddPayment;
using Backend.Application.Business.Business.Billing.Subscribe;
using Backend.Application.Business.Business.Chat.CreateChatMessage;
using Backend.Application.Business.Business.Chat.SendChatMessage;
using Backend.Application.Business.Business.Exercise.Create;
using Backend.Application.Business.Business.ExerciseType.Create;
using Backend.Application.Business.Business.ExerciseType.Update;
using Backend.Application.Business.Business.PushNotification.CreatePushNotification;
using Backend.Application.Business.Business.PushNotification.SendPushNotification;
using Backend.Application.Business.Business.Set.Create;
using Backend.Application.Business.Business.TagGroup.Create;
using Backend.Application.Business.Business.TagGroup.Update;
using Backend.Application.Business.Business.Training.Create;
using Backend.Application.Business.Business.Training.Update;
using Backend.Application.Business.Business.Users.CreateUser;
using Backend.Application.Business.Business.Users.UpdateUser;
using Backend.Application.Business.Extensions;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Backend.Service.Chat.NgChatModels;
using Backend.Service.Excel.Models.Export.Training;
using Backend.Service.Payment.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

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
            this.TagGroupMappings();
            this.ExerciseTypeMappings();
            this.TrainingMappings();
            this.ExerciseMappings();
            this.SetMappings();
            this.NotificationMappings();
            this.ExportMappings();
        }

        private void NotificationMappings()
        {
            CreateMap<CreatePushNotificationRequest, Notification>();
            CreateMap<SendPushNotificationRequest, CreatePushNotificationRequest>();
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
            CreateMap<MessageViewModel, CreateChatMessageRequest>()
                    .ForMember(x => x.SentAt, o => o.MapFrom(x => x.DateSent))
                    .ForMember(x => x.SeenAt, o => o.MapFrom(x => x.DateSeen))
                    .ForMember(x => x.ReceiverId, o => o.MapFrom(x => x.ToId))
                    .ForMember(x => x.SenderId, o => o.MapFrom(x => x.FromId));
            //.ForMember(x => x.SenderId, o => o.ConvertUsing<Guid>(c => Guid.Parse(c.FromId)));

            CreateMap<CreateChatMessageRequest, ChatMessage>();

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

        private void TrainingMappings()
        {
            CreateMap<CreateTrainingRequest, Training>();
            CreateMap<UpdateTrainingRequest, Training>();
        }

        private void ExerciseMappings()
        {
            CreateMap<CreateExerciseRequest, Exercise>();
        }

        private void SetMappings()
        {
            CreateMap<CreateSetRequest, Set>();
        }

        private void ExportMappings()
        {
            CreateMap<Training, ExportTrainingDto>()
                .ForMember(x => x.Date, y => y.MapFrom(x => x.DateTrained.Date));

            CreateMap<Exercise, ExportExerciseDto>()
                .ForMember(x => x.Exercise, y => y.MapFrom(x => x.ExerciseType.Name))
                .ForMember(x => x.ExerciseTags, y => y.MapFrom(x =>
                    EnumerableExtensions.Join(x.ExerciseType.Properties
                        .OrderBy(x => x.Tag.TagGroup.Order)
                        .Select(x => x.Tag.Value), " ")
                ));

            CreateMap<Set, ExportSetDto>();
        }
    }
}