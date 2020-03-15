using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ExerciseType.TagGroup.GetAll
{
    public class GetAllTagGroupRequestHandler : IRequestHandler<GetAllTagGroupRequest, IQueryable<Domain.Entities.ExerciseType.TagGroup>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTagGroupRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.ExerciseType.TagGroup>> Handle(GetAllTagGroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(
                    _context.TagGroups
                            .Include(x => x.Tags)
                            .Where(x => x.ApplicationUserId == request.ApplicationUserId));
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.Tag), $"Could not find exercise types for user with id: {request.ApplicationUserId} ", e);
            }
        }
    }
}