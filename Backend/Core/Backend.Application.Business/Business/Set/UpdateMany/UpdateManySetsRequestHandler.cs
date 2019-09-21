using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Set.UpdateMany
{
    public class UpdateManySetsRequestHandler : IRequestHandler<UpdateManySetsRequest, IEnumerable<Domain.Entities.TrainingLog.Set>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateManySetsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.TrainingLog.Set>> Handle(UpdateManySetsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var sets = _context.Sets.Where(x => x.ExerciseId == request.ExerciseId).AsNoTracking();

                var setsToRemove = sets.Where(x => request.Sets.All(y => y.Id != x.Id));
                var setsToAdd = request.Sets.Where(x => x.Id == Guid.Empty);
                var setsToUpdate = request.Sets.Where(x => x.Id != Guid.Empty);

                _context.Sets.RemoveRange(setsToRemove);
                _context.Sets.UpdateRange(setsToUpdate);
                _context.Sets.AddRange(setsToAdd);

                await _context.SaveChangesAsync(cancellationToken);

                return request.Sets;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.Tag), e);
            }
        }
    }
}