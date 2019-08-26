using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.Training.GetByMonth
{
    public class GetAllTrainingsByMonthRequest : IRequest<IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        public Guid ApplicationUserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public GetAllTrainingsByMonthRequest(Guid applicationUserId, int month, int year)
        {
            ApplicationUserId = applicationUserId;
            Month = month;
            Year = year;
        }
    }
}
