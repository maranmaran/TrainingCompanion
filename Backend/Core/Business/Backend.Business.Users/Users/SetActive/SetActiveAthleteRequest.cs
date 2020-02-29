using System;
using MediatR;

namespace Backend.Business.Users.Users.SetActive
{
    public class SetActiveUserRequest : IRequest
    {
        public Guid Id { get; set; }
        public bool Value { get; set; }

        public SetActiveUserRequest(Guid id, bool value)
        {
            Id = id;
            Value = value;
        }
    }
}