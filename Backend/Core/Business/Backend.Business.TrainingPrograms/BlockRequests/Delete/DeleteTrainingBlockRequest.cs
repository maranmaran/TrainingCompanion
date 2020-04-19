using System;
using MediatR;

namespace Backend.Business.TrainingPrograms.TrainingBlockRequests.Delete
{

    public class DeleteTrainingBlockRequest : IRequest<Unit>
    {
        public DeleteTrainingBlockRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
