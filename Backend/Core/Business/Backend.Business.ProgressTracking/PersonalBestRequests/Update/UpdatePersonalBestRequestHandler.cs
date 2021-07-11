using AutoMapper;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Update
{
    public class UpdatePersonalBestRequestHandler : IRequestHandler<UpdatePersonalBestRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePersonalBestRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonalBestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _context.PBs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                _mapper.Map(request, entityToUpdate);

                _context.PBs.Update(entityToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(UpdatePersonalBestRequest), e);
            }
        }
    }
}