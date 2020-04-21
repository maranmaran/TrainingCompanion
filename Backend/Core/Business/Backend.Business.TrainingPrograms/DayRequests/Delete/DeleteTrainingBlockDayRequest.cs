﻿using System;
using MediatR;

namespace Backend.Business.TrainingPrograms.DayRequests.Delete
{

    public class DeleteTrainingBlockDayRequest : IRequest<Unit>
    {
        public DeleteTrainingBlockDayRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
