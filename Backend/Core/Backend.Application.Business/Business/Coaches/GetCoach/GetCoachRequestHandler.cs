using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Coaches.GetCoach
{
    public class GetCoachRequestHandler : IRequestHandler<GetCoachRequest, Coach>
    {
        private readonly IApplicationDbContext _context;

        public GetCoachRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Coach> Handle(GetCoachRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var coach = await _context.Coaches.SingleAsync(appCoach => appCoach.Id == request.CoachId, cancellationToken);

                return coach;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Coach), request.CoachId, e);
            }
        }
    }
}
