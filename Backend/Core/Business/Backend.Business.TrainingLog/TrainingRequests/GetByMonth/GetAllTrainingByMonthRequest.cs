using System;
using System.Collections.Generic;
using MediatR;

namespace Backend.Business.TrainingLog.TrainingRequests.GetByMonth
{
    public class GetAllTrainingsByMonthRequest : IRequest<IEnumerable<Domain.Entities.TrainingLog.Training>>
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