using MediatR;
using System;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Delete
{
    public class DeleteTrainingProgramUserRequest : IRequest<Unit>
    {
        public DeleteTrainingProgramUserRequest(Guid trainingProgramUserId)
        {
            TrainingProgramUserId = trainingProgramUserId;
        }

        public Guid TrainingProgramUserId { get; set; }
    }
}