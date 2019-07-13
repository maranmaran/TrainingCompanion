using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Users.GetUser
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, ApplicationUser>
    {
        private readonly IApplicationDbContext _context;

        public GetUserRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> Handle(GetUserRequest request, CancellationToken cancellationToken)
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
