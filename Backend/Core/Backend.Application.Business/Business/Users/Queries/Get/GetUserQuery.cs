using System;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Users.Queries.Get
{
    public class GetUserQuery : IRequest<ApplicationUser>
    {
        public Guid UserId { get; set; }

        public GetUserQuery(Guid id)
        {
            UserId = id;
        }
    }
}
