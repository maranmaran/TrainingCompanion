using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Backend.Application.Business.Business.Athletes.SetActiveAthlete
{
    public class SetActiveAthleteRequest: IRequest
    {
        public Guid Id { get; set; }
        public bool Value { get; set; }

        public SetActiveAthleteRequest(Guid id, bool value)
        {
            Id = id;
            Value = value;
        }
    }
}
