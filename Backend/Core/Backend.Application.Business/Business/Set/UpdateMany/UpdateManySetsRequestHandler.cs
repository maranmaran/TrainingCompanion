﻿using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                var type = _context
                    .Exercises
                    .Include(x => x.ExerciseType)
                    .First(x => x.Id == request.ExerciseId).ExerciseType;

                var sets = _context.Sets.Where(x => x.ExerciseId == request.ExerciseId).AsNoTracking();
                TransformSets(request.Sets, type);

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

        private void TransformSets(IEnumerable<Domain.Entities.TrainingLog.Set> sets, Domain.Entities.ExerciseType.ExerciseType type)
        {
            foreach (var set in sets)
            {
                // update additional properties
                if (type.RequiresReps && type.RequiresSets)
                {
                    if (type.RequiresWeight)
                    {
                        set.Volume = set.Reps * set.Weight;
                    }
                    else if (type.RequiresBodyweight)
                    {
                        // bw
                    }
                }
            }
        }
    }
}