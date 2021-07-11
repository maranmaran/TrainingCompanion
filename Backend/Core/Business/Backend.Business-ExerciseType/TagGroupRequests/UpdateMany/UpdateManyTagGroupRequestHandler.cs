using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.TagGroupRequests.UpdateMany
{
    public class UpdateManyTagGroupRequestHandler : IRequestHandler<UpdateManyTagGroupRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateManyTagGroupRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateManyTagGroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var requestTag in request.TagGroups)
                {
                    _context.TagGroups.Update(requestTag);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Tag), e);
            }
        }
    }
}