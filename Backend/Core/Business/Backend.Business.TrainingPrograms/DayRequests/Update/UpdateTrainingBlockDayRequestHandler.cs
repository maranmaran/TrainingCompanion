using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.DayRequests.Update
{
    public class UpdateTrainingBlockDayRequestHandler : IRequestHandler<UpdateTrainingBlockDayRequest, TrainingBlockDay>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingBlockDayRequestHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TrainingBlockDay> Handle(UpdateTrainingBlockDayRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingBlockDays.Include(x => x.Trainings).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (request.RestDay)
                {
                    _context.Trainings.RemoveRange(entity.Trainings);

                    entity.Trainings = null;
                    entity.Modified = true;
                    _context.TrainingBlockDays.Update(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlockDay), e);
            }
        }
    }
}