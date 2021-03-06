﻿using MediatR;
using System;

namespace Backend.Business.TrainingLog.SetRequests.Delete
{
    public class DeleteSetRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}