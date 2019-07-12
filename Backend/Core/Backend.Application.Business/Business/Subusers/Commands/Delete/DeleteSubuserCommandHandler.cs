using Backend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;

namespace Backend.Application.Business.Business.Subusers.Commands.Delete
{
    public class DeleteSubuserCommandHandler : IRequestHandler<DeleteSubuserCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSubuserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubuserCommand request, CancellationToken cancellationToken)
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
