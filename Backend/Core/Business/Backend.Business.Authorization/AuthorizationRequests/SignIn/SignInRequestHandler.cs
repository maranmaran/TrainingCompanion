﻿using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using Backend.Business.Authorization.Interfaces;
using Backend.Business.Authorization.Utils;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Authorization.AuthorizationRequests.SignIn
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest, (CurrentUserRequestResponse response, string token)>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtTokenGenerator _jwtGenerator;
        private readonly IMediator _mediator;
        private readonly ILogger<SignInRequestHandler> _logger;

        public SignInRequestHandler(
            IApplicationDbContext context,
            IJwtTokenGenerator jwtGenerator,
            IMediator mediator,
            ILogger<SignInRequestHandler> logger)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<(CurrentUserRequestResponse response, string token)> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username || x.Email == request.Username, cancellationToken);

                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), $"Wrong username or password");

                if (user.PasswordHash != PasswordHasher.GetPasswordHash(request.Password))
                    throw new UnauthorizedAccessException("Wrong username or password");

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