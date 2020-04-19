using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Delete
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
