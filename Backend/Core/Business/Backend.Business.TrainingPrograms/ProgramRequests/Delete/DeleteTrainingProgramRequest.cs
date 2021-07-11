using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Delete
{
    public class DeleteTrainingProgramRequest : IRequest<Unit>
    {
        public DeleteTrainingProgramRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}