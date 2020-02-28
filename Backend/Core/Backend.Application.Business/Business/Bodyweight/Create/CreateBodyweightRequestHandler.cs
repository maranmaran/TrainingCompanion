using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Bodyweight.Create
{
    public class CreateBodyweightRequestHandler : IRequestHandler<CreateBodyweightRequest, Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public CreateBodyweightRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight> Handle(CreateBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entity = _mapper.Map<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>(request);

                _context.Bodyweights.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(CreateBodyweightRequest), e);
            }
        }
    }
}