using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.TrainingLog.Training.Update
{
    public class UpdateTrainingRequestHandler :
        IRequestHandler<UpdateTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.TrainingLog.Training> Handle(UpdateTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainingToUpdate = _context.Trainings.Find(request.Id);
                trainingToUpdate = _mapper.Map(request, trainingToUpdate);

                _context.Trainings.Update(trainingToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return trainingToUpdate;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}