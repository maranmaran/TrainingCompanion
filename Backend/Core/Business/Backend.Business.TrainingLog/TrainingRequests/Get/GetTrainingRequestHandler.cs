
using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.Logging.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.TrainingRequests.Get
{
    public class GetTrainingRequestHandler : IRequestHandler<GetTrainingRequest, Training>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3AccessService;
        private readonly ILoggingService _loggingService;

        public GetTrainingRequestHandler(IApplicationDbContext context, IS3Service s3AccessService, ILoggingService loggingService)
        {
            _context = context;
            _s3AccessService = s3AccessService;
            _loggingService = loggingService;
        }

        public async Task<Training> Handle(GetTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training = _context.Trainings
                    .FirstOrDefault(x => x.Id == request.TrainingId);

                if (training == null)
                {
                    var ex = new NotFoundException(nameof(Training), request.TrainingId);
                    await _loggingService.LogError(ex, "Training could not be found");
                    throw ex;
                }

                return training;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Training), $"Could not find training for {request.TrainingId} Training", e);
            }
        }
    }
}