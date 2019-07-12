using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userToUpdate = await _context.Users.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map<UpdateUserCommand, ApplicationUser>(request, userToUpdate);

                _context.Users.Update(userToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(ApplicationUser), e.Message);
            }
        }
    }
}
