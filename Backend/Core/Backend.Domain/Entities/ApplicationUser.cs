using Backend.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }

        public string Avatar { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Gender Gender { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }

        public bool Active { get; set; }

        public AccountType AccountType { get; set; }
        public int TrialDuration { get; set; }

        public Guid? UserSettingsId { get; set; }
        public virtual UserSettings UserSettings { get; set; } = new UserSettings();

        public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new HashSet<ChatMessage>();
        public virtual ICollection<MediaFile> MediaFiles { get; set; } = new HashSet<MediaFile>();
    }
}
