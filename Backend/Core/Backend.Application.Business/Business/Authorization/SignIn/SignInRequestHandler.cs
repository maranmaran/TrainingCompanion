﻿using AutoMapper;
using Backend.Application.Business.Business.Authorization.CurrentUser;
using Backend.Domain;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Authorization.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInRequest, (CurrentUserRequestResponse response, string token)>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPaymentService _paymentService;
        private readonly IJwtTokenGenerator _jwtGenerator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SignInCommandHandler(
            IApplicationDbContext context,
            IPaymentService paymentService,
            IJwtTokenGenerator jwtGenerator,
            IPasswordHasher passwordHasher,
            IMapper mapper, IMediator mediator)
        {
            _context = context;
            _paymentService = paymentService;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<(CurrentUserRequestResponse response, string token)> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Username == request.Username, cancellationToken);

                var token = _jwtGenerator.GenerateToken(user.Id);

                var response = await _mediator.Send(new CurrentUserRequest(user.Id), cancellationToken);

                return (response, token);
            }
            catch (Exception e)
            {
                throw new UnauthorizedAccessException("Failed to login.", e);
            }
        }
    }
}
