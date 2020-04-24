using AutoMapper;
using Backend.Business.TrainingPrograms.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Logging.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Create
{

    public class CreateTrainingProgramUserRequest : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ProgramId { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class CreateTrainingProgramUserRequestValidator : AbstractValidator<CreateTrainingProgramUserRequest>
    {
        public CreateTrainingProgramUserRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ProgramId).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty().Must(date => date.ToUniversalTime().Date >= DateTime.UtcNow.Date);
        }
    }


    public class CreateTrainingProgramUserRequestHandler : IRequestHandler<CreateTrainingProgramUserRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;
        private readonly ITrainingProgramAssignService _assignService;

        public CreateTrainingProgramUserRequestHandler(IApplicationDbContext context,
                                    IMapper mapper,
                                    IMediator mediator,
                                    ILoggingService logger, ITrainingProgramAssignService assignService)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _assignService = assignService;
        }


        public async Task<Unit> Handle(CreateTrainingProgramUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var program = await GetProgram(request.ProgramId, cancellationToken);
                var user = await GetUser(request.UserId, cancellationToken);

                await _assignService.Assign(program, user, request.StartDate, cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(CreateTrainingProgramUserRequest), e);
            }
        }

        public async Task<TrainingProgram> GetProgram(Guid trainingProgramId,
            CancellationToken cancellationToken = default)
        {
            var program =
                await _context.TrainingPrograms

                    .Include(x => x.TrainingBlocks)
                    .ThenInclude(x => x.Days)
                    .ThenInclude(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.Sets)

                    .Include(x => x.TrainingBlocks)
                    .ThenInclude(x => x.Days)
                    .ThenInclude(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.ExerciseType)
                    .ThenInclude(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)

                    .FirstOrDefaultAsync(x => x.Id == trainingProgramId,
                    cancellationToken);

            if (program == null)
                throw new NotFoundException(nameof(TrainingProgram), trainingProgramId);

            return program;
        }

        public async Task<ApplicationUser> GetUser(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var user =
                await _context.Users.FirstOrDefaultAsync(x => x.Id == userId,
                    cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), userId);

            return user;
        }
    }

}
