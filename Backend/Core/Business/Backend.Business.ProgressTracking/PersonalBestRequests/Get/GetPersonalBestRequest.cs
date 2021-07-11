using Backend.Domain;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Library.Logging.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Get
{
    public class GetPersonalBestRequest : IRequest<PersonalBest[]>
    {
        public Guid ExerciseTypeId { get; set; }
        public Guid ExerciseId { get; set; }
    }

    public class GetPersonalBestRequestValidator : AbstractValidator<GetPersonalBestRequest>
    {
        public GetPersonalBestRequestValidator()
        {
            // Non empty - empty
            RuleFor(x => x.ExerciseId).NotEmpty().DependentRules(() => RuleFor(x => x.ExerciseTypeId).Empty());
            RuleFor(x => x.ExerciseTypeId).NotEmpty().DependentRules(() => RuleFor(x => x.ExerciseId).Empty());
        }
    }

    public class GetPersonalBestRequestHandler : IRequestHandler<GetPersonalBestRequest, PersonalBest[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggingService _logger;

        public GetPersonalBestRequestHandler(IApplicationDbContext context,
                                    ILoggingService logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PersonalBest[]> Handle(GetPersonalBestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.ExerciseTypeId == Guid.Empty && request.ExerciseId != Guid.Empty)
                {
                    request.ExerciseTypeId =
                        (await _context.Exercises.FirstOrDefaultAsync(x => x.Id == request.ExerciseId, cancellationToken)).ExerciseTypeId;
                }

                // actual user input for PR
                var userPersonalBest =
                    await _context.PBs.OrderBy(x => x.DateAchieved).FirstOrDefaultAsync(x => x.ExerciseTypeId == request.ExerciseTypeId && !x.SystemCalculated,
                        cancellationToken);

                // system calculated personal best (with 1rm guesser)
                var systemPersonalBest =
                    await _context.PBs.OrderBy(x => x.DateAchieved).FirstOrDefaultAsync(x => x.ExerciseTypeId == request.ExerciseTypeId && x.SystemCalculated,
                        cancellationToken);

                return new[] { userPersonalBest, systemPersonalBest };
            }
            catch (Exception e)
            {
                await _logger.LogError(e.Message);
                throw new Exception(nameof(GetPersonalBestRequest), e);
            }
        }
    }
}