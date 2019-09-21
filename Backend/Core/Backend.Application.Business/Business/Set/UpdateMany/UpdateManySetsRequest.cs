using System;
using System.Collections.Generic;
using MediatR;

namespace Backend.Application.Business.Business.Set.Update
{
    public class UpdateManySetsRequest: IRequest<IEnumerable<Domain.Entities.TrainingLog.Set>>
    {
        public Guid ExerciseId { get; set; }
        public IEnumerable<Domain.Entities.TrainingLog.Set> Sets { get; set; }
    }
}