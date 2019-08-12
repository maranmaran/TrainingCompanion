using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Domain.Entities
{
    public class Training
    {
        public Guid Id { get; set; }

        public DateTime DateTrained { get; set; }
        public string Note { get; set; }

        public bool NoteRead { get; set; }

        public Guid AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
        public virtual ICollection<MediaFile> Media { get; set; } = new HashSet<MediaFile>();
    }
    public class Exercise
    {
        public Guid Id { get; set; }

        public int Sets { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; } = new HashSet<Lift>();
    }

    public class Lift
    {
        public Guid Id { get; set; }

        public double Weight { get; set; }
        public double Reps { get; set; }
        public TimeSpan Time { get; set; }
        public double Rpe { get; set; }
        public string Intensity { get; set; }
        public double Volume { get; set; }
        public string AverageVelocity { get; set; }
        public double ProjectedMax { get; set; }
    }

    public class ExerciseType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool? RequiresReps { get; set; }
        public bool? RequiresSets { get; set; }
        public bool? RequiresWeight { get; set; }
        public bool? RequiresBodyweight { get; set; }
        public bool? RequiresTime { get; set; }

        public string BarType { get; set; }
        public string StanceGrip { get; set; }
        public string RangeOfMotion { get; set; }
        public string Tempo { get; set; }

        public bool? IsActive { get; set; }
        public string Category { get; set; }
        public string RpeChart { get; set; }

        public string AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }

        public virtual ICollection<ExerciseMax> ExerciseMaxes { get; set; }
    }

    public class Bodyweight
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public Guid AthleteId { get; set; }
        public Athlete Athlete { get; set; }

    }

    public class ExerciseMax
    {
        public Guid Id { get; set; }

        public Guid AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }

        public Guid ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }

        public double Max { get; set; }

        public double WilksScore { get; set; }
        public double IpfPoints { get; set; }
    }

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

        public Guid AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }

        public Guid FatigueResultId { get; set; }
        public virtual FatigueResult FatigueResult { get; set; }

    }

    public class FatigueResult
    {
        public Guid Id { get; set; }
        public double Value { get; set; }

        public long FatigueEntryId { get; set; }
        public virtual FatigueEntry FatigueEntry { get; set; }
    }


}
