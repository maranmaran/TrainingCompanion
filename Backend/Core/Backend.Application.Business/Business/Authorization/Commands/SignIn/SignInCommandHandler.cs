using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Business.Business.Authorization.Queries;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Authorization.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, (CurrentUserQueryResponse response, string token)>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPaymentService _paymentService;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SignInCommandHandler(
            IApplicationDbContext context,
            IPaymentService paymentService,
            IJwtTokenGenerator tokenGenerator,
            IPasswordHasher passwordHasher,
            IMapper mapper, IMediator mediator)
        {
            _context = context;
            _paymentService = paymentService;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<(CurrentUserQueryResponse response, string token)> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Username == request.Username, cancellationToken: cancellationToken);

                if (user == null) throw new NotFoundException(nameof(ApplicationUser), request);

                if (user.PasswordHash != _passwordHasher.GetPasswordHash(request.Password)) throw new UnauthorizedAccessException("Wrong password.");

                var token = _tokenGenerator.GenerateToken(user.Id);

                var response = await _mediator.Send(new CurrentUserQuery(user.Id), cancellationToken);

                return (response, token);
            }
            catch (Exception e)
            {
                throw new UnauthorizedAccessException("Failed to login.", e);
            }
        }
    }
}
