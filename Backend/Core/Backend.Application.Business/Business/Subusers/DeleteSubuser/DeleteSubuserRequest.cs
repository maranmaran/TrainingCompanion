using System;
using MediatR;

namespace Backend.Application.Business.Business.Subusers.DeleteSubuser
{
    public class DeleteSubuserRequest : IRequest
    {
        public DeleteSubuserRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
