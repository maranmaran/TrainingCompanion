using System;
using MediatR;

namespace Backend.Application.Business.Business.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteUserRequest(Guid id)
        {
            Id = id;
        }
    }
}
