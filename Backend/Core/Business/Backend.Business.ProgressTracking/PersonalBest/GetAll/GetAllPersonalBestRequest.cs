using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBest.GetAll
{
    public class GetAllPersonalBestRequestValidator : AbstractValidator<GetAllPersonalBestRequest>
    {

    }


    public class GetAllPersonalBestRequest : IRequest<Unit>
    {

    }

    public class GetAllPersonalBestRequestHandler : IRequestHandler<GetAllPersonalBestRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public GetAllPersonalBestRequestHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<Unit> Handle(GetAllPersonalBestRequest request, CancellationToken cancellationToken)
        {

            try
            {
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetAllPersonalBestRequest), e);
            }
        }
    }
}
