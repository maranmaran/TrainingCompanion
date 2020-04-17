using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Library.Logging.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Create
{

    public class CreateTrainingProgramRequest : IRequest<TrainingProgram>
    {
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class CreateTrainingProgramRequestValidator : AbstractValidator<TrainingProgram>
    {
        public CreateTrainingProgramRequestValidator()
        {
            RuleFor(x => x.CreatorId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class CreateTrainingProgramRequestHandler : IRequestHandler<CreateTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;

        public CreateTrainingProgramRequestHandler(IApplicationDbContext context,
                                    IMapper mapper,
                                    IMediator mediator,
                                    ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }


        public async Task<TrainingProgram> Handle(CreateTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CreateTrainingProgramRequest, TrainingProgram>(request);

                _context.TrainingPrograms.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingProgram), e);
            }
        }
    }

}
