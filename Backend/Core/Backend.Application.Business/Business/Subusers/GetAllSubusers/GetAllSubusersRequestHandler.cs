using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Subusers.GetAllSubusers
{
    public class GetAllSubusersRequestHandler : IRequestHandler<GetAllSubusersRequest, IQueryable<ApplicationUser>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSubusersRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ApplicationUser>> Handle(GetAllSubusersRequest request, CancellationToken cancellationToken)
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
