using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Athletes.UpdateAthlete
{
    public class UpdateAthleteRequestHandler : IRequestHandler<UpdateAthleteRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAthleteRequestHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAthleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var athleteToUpdate = await _context.Athletes.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map<UpdateAthleteRequest, Athlete>(request, athleteToUpdate);

                _context.Athletes.Update(athleteToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(Athlete), request.Id, e);
            }
        }
    }
}
