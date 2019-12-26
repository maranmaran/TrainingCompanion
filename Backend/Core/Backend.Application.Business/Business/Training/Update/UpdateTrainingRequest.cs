using MediatR;
using System;

namespace Backend.Application.Business.Business.Training.Update
{
    public class UpdateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public bool NoteRead { get; set; }
    }
}