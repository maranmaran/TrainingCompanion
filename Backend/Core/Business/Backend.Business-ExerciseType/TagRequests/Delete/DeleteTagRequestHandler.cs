using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Exercises.TagRequests.Delete
{
    public class DeleteTagRequestHandler : IRequestHandler<DeleteTagRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTagRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var tag =
                    await _context.Tags.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.Tags.Remove(tag);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Tag), e);
            }
        }
    }
}