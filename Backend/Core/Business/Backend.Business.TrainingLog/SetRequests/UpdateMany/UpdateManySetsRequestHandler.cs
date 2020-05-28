using Backend.Business.TrainingLog.Code;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.SetRequests.UpdateMany
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
                var type = _context
                    .Exercises
                    .Include(x => x.ExerciseType)
                    .ThenInclude(x => x.ApplicationUser)
                    .ThenInclude(x => x.UserSetting)
                    .First(x => x.Id == request.ExerciseId).ExerciseType;

                var sets = await _context.Sets.Where(x => x.ExerciseId == request.ExerciseId).AsNoTracking().ToListAsync(cancellationToken);

                TransformSets(request.Sets, type, type.ApplicationUser.UserSetting);

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
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Set), e);
            }
        }

        private void TransformSets(IEnumerable<Domain.Entities.TrainingLog.Set> sets, ExerciseType type, UserSetting settings)
        {
            foreach (var set in sets)
            {
                if (type.RequiresWeight && !type.RequiresBodyweight)
                {
                    set.Weight = set.Weight.ToMetricSystem(settings.UnitSystem); // make sure everything going in from weight is METRIC!
                }

                // update additional properties
                if (type.RequiresReps && type.RequiresSets)
                {

                    if (type.RequiresWeight)
                    {
                        set.Volume = set.Reps * set.Weight;
                    }
                }

                if (settings.UseRpeSystem && type.RequiresReps && type.RequiresSets && (type.RequiresWeight || type.RequiresBodyweight))
                {
                    set.ProjectedMax = RpeRepsTable.CalculateLiftMax(set.Reps, settings.RpeSystem == RpeSystem.Rpe ? set.Rpe : 10 - set.Rir, set.Weight);
                }
            }
        }
    }
}