using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.TrainingLog.SetRequests.UpdateMany
{
    public class UpdateManySetsRequest : IRequest<IEnumerable<Domain.Entities.TrainingLog.Set>>
    {
        public Guid ExerciseId { get; set; }
        public IEnumerable<Domain.Entities.TrainingLog.Set> Sets { get; set; }
    }
}