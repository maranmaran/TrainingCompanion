using System;
using MediatR;

namespace Backend.Business.TrainingLog.Set.Delete
{
    public class DeleteSetRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}