namespace Backend.Service.Chat.NgChatModels
{
    public class ChatParticipantViewModel
    {
        public ChatParticipantTypeEnum ParticipantType { get; set; }
        public string Id { get; set; }
        public ChatParticipantStatus Status { get; set; }
        public string Avatar { get; set; }
        public string DisplayName { get; set; }
    }
}
