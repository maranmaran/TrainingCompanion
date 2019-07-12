using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Service.Chat.NgChatModels
{
    public class GroupChatParticipantViewModel : ChatParticipantViewModel
    {
        public IList<ChatParticipantViewModel> ChattingTo { get; set; }
    }
}
