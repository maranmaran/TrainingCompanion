using System;

namespace Backend.Domain.Entities.ProgressTracking.Fatigue
{
    public class FatigueResult
    {
        public Guid Id { get; set; }
        public double Value { get; set; }

        public Guid FatigueEntryId { get; set; }
        public virtual FatigueEntry FatigueEntry { get; set; }
    }
}