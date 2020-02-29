using System;
using MediatR;

namespace Backend.Business.TrainingLog.Training.Update
{
    public class UpdateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public bool NoteRead { get; set; }
    }
}