using MediatR;
using System;

namespace Backend.Application.Business.Business.Training.Delete
{
    public class DeleteTrainingRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}