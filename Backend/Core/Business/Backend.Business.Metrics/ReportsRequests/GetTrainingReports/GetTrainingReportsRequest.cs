﻿using MediatR;
using System;

namespace Backend.Business.Reports.ReportsRequests.GetTrainingReports
{
    public class GetTrainingReportsRequest : IRequest<GetTrainingReportsResponse>
    {
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
    }
}