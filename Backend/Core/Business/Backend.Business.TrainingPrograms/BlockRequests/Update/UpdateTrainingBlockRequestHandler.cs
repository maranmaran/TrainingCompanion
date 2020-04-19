using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.TrainingBlockRequests.Update
{
    public class UpdateTrainingBlockRequestHandler : IRequestHandler<UpdateTrainingBlockRequest, TrainingBlock>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingBlockRequestHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<TrainingBlock> Handle(UpdateTrainingBlockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingBlocks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, entity);

                _context.TrainingBlocks.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlock), e);
            }
        }
    }
}