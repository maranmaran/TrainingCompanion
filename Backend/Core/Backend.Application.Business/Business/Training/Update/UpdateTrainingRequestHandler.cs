using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Training.Update
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
                _context.Trainings.Update(request.Training);

                await _context.SaveChangesAsync(cancellationToken);

                return request.Training;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}