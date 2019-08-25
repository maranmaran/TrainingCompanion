using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Training.Create
{
    public class CreateTrainingRequestHandler :
        IRequestHandler<CreateTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;

        public CreateTrainingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.TrainingLog.Training> Handle(CreateTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return new Domain.Entities.TrainingLog.Training();
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}