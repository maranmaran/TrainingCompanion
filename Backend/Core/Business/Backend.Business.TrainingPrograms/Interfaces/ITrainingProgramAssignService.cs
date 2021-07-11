using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.Interfaces
{
    public interface ITrainingProgramAssignService
    {
        Task<TrainingProgramUser> Assign(TrainingProgram trainingProgram, ApplicationUser user, DateTime startDate, CancellationToken cancellationToken = default);
    }
}