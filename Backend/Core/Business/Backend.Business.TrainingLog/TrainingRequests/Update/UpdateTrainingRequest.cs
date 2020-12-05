using MediatR;
using System;

namespace Backend.Business.TrainingLog.TrainingRequests.Update
{
    public class UpdateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public Guid Id { get; set; }
        public Guid TrainingBlockDayId { get; set; }
        public string Note { get; set; }
        public bool NoteRead { get; set; }
        public DateTime DateTrained { get; set; }
    }
}