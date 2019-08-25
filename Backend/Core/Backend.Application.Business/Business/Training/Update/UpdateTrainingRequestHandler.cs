using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Business.Business.ExerciseType.Update;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Training.Update
{
    public class UpdateTrainingRequestHandler :
        IRequestHandler<UpdateTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTrainingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.TrainingLog.Training> Handle(UpdateTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return new Domain.Entities.TrainingLog.Training();
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}