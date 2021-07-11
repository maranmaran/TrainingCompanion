using Backend.Domain.Enum;
using MediatR;
using System;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequest : IRequest<Domain.Entities.ProgressTracking.PersonalBest>
    {
        public double? Reps { get; set; }
        public double? Value { get; set; }
        public DateTime DateAchieved { get; set; }
        public double? Bodyweight { get; set; }
        public Guid ExerciseTypeId { get; set; }
        public UnitSystem UnitSystem { get; set; }
    }
}