using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ExerciseType.TagGroup.Delete
{
    public class DeleteTagGroupRequestHandler : IRequestHandler<DeleteTagGroupRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTagGroupRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTagGroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TagGroups.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.TagGroups.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Domain.Entities.ExerciseType.Tag), e);
            }
        }
    }
}