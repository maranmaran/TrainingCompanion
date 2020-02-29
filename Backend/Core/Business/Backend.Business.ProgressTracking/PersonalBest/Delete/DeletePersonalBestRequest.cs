using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business.ProgressTracking.PersonalBest.Create;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBest.Delete
{
    public class CreateBodyweightRequest : IRequest<Unit>
    {
    }

    public class CreatePersonalBestRequestHandler : IRequestHandler<CreatePersonalBestRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public CreatePersonalBestRequestHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<Unit> Handle(CreatePersonalBestRequest request, CancellationToken cancellationToken)
        {

            try
            {
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(CreatePersonalBestRequest), e);
            }
        }
    }
}
