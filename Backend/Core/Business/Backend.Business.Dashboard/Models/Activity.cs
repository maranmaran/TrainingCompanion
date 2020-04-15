using System;

namespace Backend.Business.Dashboard.Models
{
    public class Activity
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } // read this as Name not Username
        public string UserAvatar { get; set; }
        public ActivityType Type { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } // some kind of payload.. depending on type.. can be null
        public string JsonEntity { get; set; }
    }

    public enum ActivityType
    {
        Training,
        MediaFile,
        Bodyweight,
        PersonalBest
    }
}
