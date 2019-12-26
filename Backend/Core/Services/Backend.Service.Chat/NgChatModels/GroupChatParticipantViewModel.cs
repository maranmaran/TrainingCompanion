using System.Collections.Generic;

namespace Backend.Service.Chat.NgChatModels
{
    public class GroupChatParticipantViewModel : ChatParticipantViewModel
    {
        public IList<ChatParticipantViewModel> ChattingTo { get; set; }
    }
}