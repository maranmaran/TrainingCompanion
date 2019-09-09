using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Set.Create
{
    public class CreateSetRequestHandler :
        IRequestHandler<CreateSetRequest, Domain.Entities.TrainingLog.Set>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSetRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.TrainingLog.Set> Handle(CreateSetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newSet = _mapper.Map<Domain.Entities.TrainingLog.Set>(request);

                await _context.Sets.AddAsync(newSet, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return newSet;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Set), e);
            }
        }
    }
}