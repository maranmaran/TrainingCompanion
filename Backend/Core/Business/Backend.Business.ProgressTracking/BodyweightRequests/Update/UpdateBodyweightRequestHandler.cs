using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Update
{
    public class UpdateBodyweightRequestHandler : IRequestHandler<Update.UpdateBodyweightRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;



        public UpdateBodyweightRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(Update.UpdateBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entityToUpdate = await _context.Bodyweights.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                _mapper.Map(request, entityToUpdate);

                _context.Bodyweights.Update(entityToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(Update.UpdateBodyweightRequest), e);
            }
        }
    }
}