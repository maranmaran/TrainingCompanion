using Backend.Domain.Entities.User;
using System;

namespace Backend.Domain.Entities.ProgressTracking.Fatigue
{
    public class FatigueEntry
    {
        public Guid Id { get; set; }

        public DateTime EntryDate { get; set; }

        public int HeartRate1 { get; set; }
        public int HeartRate2 { get; set; }
        public int HeartRate3 { get; set; }
        public int HeartRate4 { get; set; }
        public int HeartRate5 { get; set; }

        public int LegSoreness { get; set; }
        public int PushSoreness { get; set; }
        public int PullSoreness { get; set; }

        public int Tiredness { get; set; }
        public int PerceivedRecovery { get; set; }
        public int MotivationToTrain { get; set; }
        public int PerceivedTrainingLoad { get; set; }

        public int HoursSlept { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Guid FatigueResultId { get; set; }
        public virtual FatigueResult FatigueResult { get; set; }
    }
}