using AutoMapper;
using Backend.Domain;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Delete
{
    public class DeleteTrainingProgramUserRequestHandler : IRequestHandler<DeleteTrainingProgramUserRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _logger;

        public DeleteTrainingProgramUserRequestHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator,
            ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }


        public async Task<Unit> Handle(DeleteTrainingProgramUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var programConnectionToDelete = await _context
                                                        .TrainingProgramUsers
                                                        .FirstOrDefaultAsync(x => x.Id == request.TrainingProgramUserId, cancellationToken);

                var futureTrainings = _context.Trainings
                                                                    .Include(x => x.Media)
                                                                    .Include(x => x.Exercises)
                                                                    .ThenInclude(x => x.Media)
                    .Where(x =>
                        x.TrainingProgramId == programConnectionToDelete.TrainingProgramId &&
                        x.ApplicationUserId == programConnectionToDelete.ApplicationUserId &&
                        x.DateTrained >= DateTime.UtcNow);

                // delete future trainings and connection
                _context.TrainingProgramUsers.Remove(programConnectionToDelete);
                _context.Trainings.RemoveRange(futureTrainings);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(DeleteTrainingProgramUserRequest), e);
            }
        }
    }
}