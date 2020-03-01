using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequestHandler : IRequestHandler<CreatePersonalBestRequest, Domain.Entities.ProgressTracking.PersonalBest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public CreatePersonalBestRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Domain.Entities.ProgressTracking.PersonalBest> Handle(CreatePersonalBestRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entity = _mapper.Map<Domain.Entities.ProgressTracking.PersonalBest>(request);

                _context.PBs.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(CreatePersonalBestRequest), e);
            }
        }
    }
}