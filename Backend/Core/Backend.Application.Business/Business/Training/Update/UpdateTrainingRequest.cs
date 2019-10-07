using System;
using System.Collections.Generic;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.User;
using MediatR;

namespace Backend.Application.Business.Business.Training.Update
{
    public class UpdateTrainingRequest : IRequest<Domain.Entities.TrainingLog.Training>
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public bool NoteRead { get; set; }
    }
}
