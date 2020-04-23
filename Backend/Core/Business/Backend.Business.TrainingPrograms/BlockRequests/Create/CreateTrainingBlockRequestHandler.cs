using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Library.Logging.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.BlockRequests.Create
{
    public class CreateTrainingBlockRequestHandler : IRequestHandler<CreateTrainingBlockRequest, TrainingBlock>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;

        public CreateTrainingBlockRequestHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator,
            ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }


        public async Task<TrainingBlock> Handle(CreateTrainingBlockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CreateTrainingBlockRequest, TrainingBlock>(request);
                entity = await ScaffoldTrainingDays(entity);

                _context.TrainingBlocks.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlock), e);
            }
        }

        public async Task<TrainingBlock> ScaffoldTrainingDays(TrainingBlock entity)
        {
            var days = new List<TrainingBlockDay>();
            for (var i = 0; i < entity.DurationInDays; i++)
            {
                days.Add(new TrainingBlockDay()
                {
                    Order = i + 1,
                });
            }
            entity.Days = days;

            return entity;
        }
    }
}