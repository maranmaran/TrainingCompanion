using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.TrainingLog.Training.Create
{
    public class CreateTrainingRequestHandler :
        IRequestHandler<CreateTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTrainingRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.TrainingLog.Training> Handle(CreateTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newTraining = _mapper.Map<Domain.Entities.TrainingLog.Training>(request);

                await _context.Trainings.AddAsync(newTraining, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return newTraining;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}