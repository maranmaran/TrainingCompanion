using System;

namespace Backend.Domain.Deserializators
{
    public class TrainingDeserializeResult
    {
        public Guid Id { get; set; }

        public DateTime DateTrained { get; set; }
        public string Note { get; set; }

        public bool NoteRead { get; set; }

        public Guid ApplicationUserId { get; set; }
    }
}