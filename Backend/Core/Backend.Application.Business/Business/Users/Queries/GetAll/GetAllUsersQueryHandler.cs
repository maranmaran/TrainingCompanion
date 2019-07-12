using Backend.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;

namespace Backend.Application.Business.Business.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IQueryable<ApplicationUser>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ApplicationUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_context.Users);
            }
            catch (Exception e)
            {
                throw new NotFoundException("Could not get users.", e);
            }
        }
    }
}
