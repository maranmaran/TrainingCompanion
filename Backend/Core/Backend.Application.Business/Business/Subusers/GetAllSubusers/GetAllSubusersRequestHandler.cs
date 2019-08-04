using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                // get all explicitly
                if (request.UserId == Guid.Empty)
                {
                    return _context.Users.Where(x => x.ParentId.HasValue);
                }

                // get some
                var user = await _context.Users.Include(x => x.Subusers).SingleAsync(x => x.Id == request.UserId, cancellationToken);
                switch (user.AccountType)
                {
                    case AccountType.Admin:
                        return _context.Users;
                    case AccountType.User:
                        return user.Subusers.AsQueryable();
                    //subuser can't retrieve subusers
                    default:
                        throw new Exception($"Could not fetch subusers for account type: {user.AccountType}");
                }
            }
            catch (Exception e)
            {
                throw new NotFoundException("Could not get users.", e);
            }
        }
    }
}
