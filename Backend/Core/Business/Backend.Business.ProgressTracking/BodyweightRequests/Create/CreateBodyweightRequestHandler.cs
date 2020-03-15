using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Create
{
    public class CreateBodyweightRequestHandler : IRequestHandler<CreateBodyweightRequest, Bodyweight>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public CreateBodyweightRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Bodyweight> Handle(CreateBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entity = _mapper.Map<Bodyweight>(request);

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