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
        IRequestHandler<UpdateTrainingRequest, UpdateTrainingRequestResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateTrainingRequestResponse> Handle(UpdateTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Trainings.Attach(request.Training).CurrentValues.SetValues(request.Training);
                _context.Trainings.Update(request.Training);

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateTrainingRequestResponse()
                {
                    Training = request.Training,
                };
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}