using System;
using MediatR;

namespace Backend.Application.Business.Business.Authorization.Queries
{
    public class CurrentUserQuery : IRequest<CurrentUserQueryResponse>
    {
        public Guid UserId { get; set; }

        public CurrentUserQuery(string userId)
        {
            UserId = Guid.Parse(userId);
        }

        public CurrentUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
