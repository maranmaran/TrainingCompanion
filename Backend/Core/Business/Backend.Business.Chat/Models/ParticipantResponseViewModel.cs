﻿namespace Backend.Business.Chat.Models
{
    public class ParticipantResponseViewModel
    {
        public ChatParticipantViewModel Participant { get; set; }
        public ParticipantMetadataViewModel Metadata { get; set; }
    }
}