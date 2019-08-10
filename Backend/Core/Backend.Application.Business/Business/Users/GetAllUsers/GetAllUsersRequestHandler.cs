using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Users.GetAllUsers
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IQueryable<ApplicationUser>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ApplicationUser>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_context.Users);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), "Something went wrong fetching users", e);
            }
        }
    }
}
