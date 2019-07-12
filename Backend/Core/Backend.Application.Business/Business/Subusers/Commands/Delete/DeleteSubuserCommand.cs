using MediatR;
using System;

namespace Backend.Application.Business.Business.Subusers.Commands.Delete
{
    public class DeleteSubuserCommand : IRequest
    {
        public DeleteSubuserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
