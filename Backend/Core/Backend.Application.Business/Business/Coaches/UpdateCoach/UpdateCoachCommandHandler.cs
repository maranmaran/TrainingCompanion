using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Coaches.UpdateCoach
{
    public class UpdateCoachRequestHandler : IRequestHandler<UpdateCoachRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCoachRequestHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCoachRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var coachToUpdate = await _context.Coaches.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map<UpdateCoachRequest, Coach>(request, coachToUpdate);

                _context.Coaches.Update(coachToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(Coach), e.Message);
            }
        }
    }
}
