using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.TrainingBlockRequests.Get
{
    public class GetTrainingBlockRequestHandler : IRequestHandler<GetTrainingBlockRequest, TrainingBlock>
    {
        private readonly IApplicationDbContext _context;

        public GetTrainingBlockRequestHandler(IApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<TrainingBlock> Handle(GetTrainingBlockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity =
                    await _context.TrainingBlocks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity == null)
                    throw new NotFoundException(nameof(TrainingBlock), request.Id);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlock), e);
            }
        }
    }
}