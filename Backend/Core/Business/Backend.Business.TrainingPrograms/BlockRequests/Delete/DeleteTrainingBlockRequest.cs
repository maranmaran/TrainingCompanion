using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.BlockRequests.Delete
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