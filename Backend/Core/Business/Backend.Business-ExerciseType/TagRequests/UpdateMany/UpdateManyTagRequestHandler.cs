using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ExerciseType.Tag.UpdateMany
{
    public class UpdateManyTagRequestHandler : IRequestHandler<UpdateManyTagRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateManyTagRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateManyTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var requestTag in request.ExerciseProperties)
                {
                    _context.Tags.Update(requestTag);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.Tag), e);
            }
        }
    }
}