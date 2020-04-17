using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Delete
{

    public class DeleteTrainingProgramRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }


    public class DeleteTrainingProgramRequestHandler : IRequestHandler<DeleteTrainingProgramRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTrainingProgramRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(DeleteTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _context.TrainingPrograms.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(DeleteTrainingProgramRequest), e);
            }
        }
    }

}
