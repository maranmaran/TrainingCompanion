using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Library.Logging.Interfaces;
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
    }

    public class GetPersonalBestRequestHandler : IRequestHandler<GetPersonalBestRequest, PersonalBest[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;

        public GetPersonalBestRequestHandler(IApplicationDbContext context,
                                    IMapper mapper,
                                    IMediator mediator,
                                    ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }


        public async Task<PersonalBest[]> Handle(GetPersonalBestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userPersonalBest =
                    await _context.PBs.OrderBy(x => x.DateAchieved).FirstOrDefaultAsync(x => x.ExerciseTypeId == request.ExerciseTypeId && !x.SystemCalculated,
                        cancellationToken);

                var systemPersonalBest =
                    await _context.PBs.OrderBy(x => x.DateAchieved).FirstOrDefaultAsync(x => x.ExerciseTypeId == request.ExerciseTypeId && x.SystemCalculated,
                        cancellationToken);

                return new[] { userPersonalBest, systemPersonalBest };
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetPersonalBestRequest), e);
            }
        }
    }

}
