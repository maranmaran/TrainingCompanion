using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Library.Logging.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.DayRequests.Create
{
    public class CreateTrainingBlockDayRequestHandler : IRequestHandler<CreateTrainingBlockDayRequest, TrainingBlockDay>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;

        public CreateTrainingBlockDayRequestHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator,
            ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<TrainingBlockDay> Handle(CreateTrainingBlockDayRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CreateTrainingBlockDayRequest, TrainingBlockDay>(request);

                _context.TrainingBlockDays.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlockDay), e);
            }
        }
    }
}