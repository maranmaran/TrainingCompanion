using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Subusers.DeleteSubuser
{
    public class DeleteSubuserRequestHandler : IRequestHandler<DeleteSubuserRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSubuserRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubuserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // get user and it's parent
                var user = await _context
                    .Users
                    .Include(x => x.Parent)
                    .SingleAsync(u => u.Id == request.Id, cancellationToken);
                var parent = user.Parent;

                // remove subuser from parent, then remove user completely
                parent.Subusers.Remove(user);
                _context.Users.Remove(user);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(ApplicationUser), request.Id, e.Message);
            }
        }
    }
}
