using Backend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;

namespace Backend.Application.Business.Business.Users.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
    {
        private readonly IApplicationDbContext _context;

        public GetUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(appUser => appUser.Id == request.UserId, cancellationToken);

                return user;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.UserId, e);
            }
        }
    }
}
