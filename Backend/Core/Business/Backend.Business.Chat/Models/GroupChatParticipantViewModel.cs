using System.Collections.Generic;

namespace Backend.Business.Chat.Models
{
    public class GroupChatParticipantViewModel : ChatParticipantViewModel
    {
        public IList<ChatParticipantViewModel> ChattingTo { get; set; }
    }
}