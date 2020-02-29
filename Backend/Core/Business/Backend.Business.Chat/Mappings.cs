using AutoMapper;
using Backend.Business.Chat.Chat.CreateChatMessage;
using Backend.Business.Chat.Chat.SendChatMessage;
using Backend.Business.Chat.Models;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.User;

namespace Backend.Business.Chat
{
    public class Mappings : Profile
    {
        public Mappings()
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
    }
}
