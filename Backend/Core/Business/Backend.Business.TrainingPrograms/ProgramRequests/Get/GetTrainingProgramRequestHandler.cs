using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Get
{
    public class GetTrainingProgramRequestHandler : IRequestHandler<GetTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;

        public GetTrainingProgramRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TrainingProgram> Handle(GetTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity =
                    await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity == null)
                    throw new NotFoundException(nameof(TrainingProgram), request.Id);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingProgram), e);
            }
        }
    }
}