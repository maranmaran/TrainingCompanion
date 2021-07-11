using MediatR;
using System;
using System.Linq;

namespace Backend.Business.TrainingLog.TrainingRequests.GetByWeek
{
    public class GetAllTrainingsByWeekRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        public Guid ApplicationUserId { get; set; }
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }

        public GetAllTrainingsByWeekRequest(Guid applicationUserId, DateTime weekStart, DateTime weekEnd)
        {
            ApplicationUserId = applicationUserId;
            WeekStart = weekStart;
            WeekEnd = weekEnd;
        }
    }
}