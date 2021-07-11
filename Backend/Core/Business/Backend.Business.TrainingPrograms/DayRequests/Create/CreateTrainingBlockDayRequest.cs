using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;

namespace Backend.Business.TrainingPrograms.DayRequests.Create
{
    public class CreateTrainingBlockDayRequest : IRequest<TrainingBlockDay>
    {
        public int Order { get; set; }
    }
}