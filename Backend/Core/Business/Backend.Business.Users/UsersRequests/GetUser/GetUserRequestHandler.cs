using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Users.UsersRequests.GetUser
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
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id || x.Email == request.Email, cancellationToken);
                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), $"{request.Id} {request.Email}");

                return user;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), e);
            }
        }
    }
}