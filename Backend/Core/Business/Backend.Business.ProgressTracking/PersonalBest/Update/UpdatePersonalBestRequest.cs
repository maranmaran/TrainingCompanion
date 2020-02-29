using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBest.Update
{
    public class UpdatePersonalBestRequestValidator : AbstractValidator<UpdatePersonalBestRequest>
    {

    }

    public class UpdatePersonalBestRequest : IRequest<Unit>
    {

    }

    public class UpdatePersonalBestRequestHandler : IRequestHandler<Update.UpdatePersonalBestRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public UpdatePersonalBestRequestHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<Unit> Handle(Update.UpdatePersonalBestRequest request, CancellationToken cancellationToken)
        {

            try
            {
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(Update.UpdatePersonalBestRequest), e);
            }
        }
    }
}
