using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.TagGroupRequests.GetAll
{
    public class GetAllTagGroupRequestHandler : IRequestHandler<GetAllTagGroupRequest, IQueryable<TagGroup>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTagGroupRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<TagGroup>> Handle(GetAllTagGroupRequest request, CancellationToken cancellationToken)
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
                throw new NotFoundException(nameof(Tag), $"Could not find exercise types for user with id: {request.ApplicationUserId} ", e);
            }
        }
    }
}