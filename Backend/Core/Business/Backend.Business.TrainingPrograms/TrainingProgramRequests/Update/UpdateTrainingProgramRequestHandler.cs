using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Update
{
    public class UpdateTrainingProgramRequestHandler : IRequestHandler<UpdateTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingProgramRequestHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<TrainingProgram> Handle(UpdateTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, entity);

                _context.TrainingPrograms.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(UpdateTrainingProgramRequest), e);
            }
        }
    }
}