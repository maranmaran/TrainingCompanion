using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Users.UpdateUser
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRequestHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userToUpdate = await _context.Users.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map<UpdateUserRequest, ApplicationUser>(request, userToUpdate);

                _context.Users.Update(userToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(ApplicationUser), request.Id, e);
            }
        }
    }
}
