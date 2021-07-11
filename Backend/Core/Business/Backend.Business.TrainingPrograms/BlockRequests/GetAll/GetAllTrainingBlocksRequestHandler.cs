using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.BlockRequests.GetAll
{
    public class GetAllTrainingBlocksRequestHandler : IRequestHandler<GetAllTrainingBlocksRequest, IEnumerable<TrainingBlock>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingBlocksRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingBlock>> Handle(GetAllTrainingBlocksRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _context.TrainingBlocks.Where(x => x.TrainingProgramId == request.TrainingProgramId)
                    .ToListAsync(cancellationToken);

                return entities;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(IEnumerable<TrainingBlock>), e);
            }
        }
    }
}