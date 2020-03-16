using System;

namespace Backend.Business.Dashboard.Models
{
    public class Activity
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } // read this as Name not Username
        public ActivityType Type { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } // some kind of payload.. depending on type.. can be null
    }

    public enum ActivityType
    {
        Training,
        MediaFile,
        Bodyweight,
        PersonalBest
    }
}
