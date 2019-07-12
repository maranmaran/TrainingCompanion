using Backend.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;

namespace Backend.Application.Business.Business.Subusers.Queries.GetAll
{
    public class GetAllSubusersQueryHandler : IRequestHandler<GetAllSubusersQuery, IQueryable<ApplicationUser>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSubusersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ApplicationUser>> Handle(GetAllSubusersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_context.Users.Where(x => x.ParentId.HasValue));
            }
            catch (Exception e)
            {
                throw new NotFoundException("Could not get users.", e);
            }
        }
    }
}
