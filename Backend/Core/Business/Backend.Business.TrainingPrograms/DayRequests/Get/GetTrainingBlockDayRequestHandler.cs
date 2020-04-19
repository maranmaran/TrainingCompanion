using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Get
{
    public class GetTrainingBlockDayRequestHandler : IRequestHandler<GetTrainingBlockDayRequest, TrainingBlockDay>
    {
        private readonly IApplicationDbContext _context;

        public GetTrainingBlockDayRequestHandler(IApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<TrainingBlockDay> Handle(GetTrainingBlockDayRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity =
                    await _context.TrainingBlockDays.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity == null)
                    throw new NotFoundException(nameof(TrainingBlockDay), request.Id);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlockDay), e);
            }
        }
    }
}