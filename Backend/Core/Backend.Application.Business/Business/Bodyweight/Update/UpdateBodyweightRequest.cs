using MediatR;
using System;

namespace Backend.Application.Business.Business.Bodyweight.Update
{
    public class UpdateBodyweightRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
