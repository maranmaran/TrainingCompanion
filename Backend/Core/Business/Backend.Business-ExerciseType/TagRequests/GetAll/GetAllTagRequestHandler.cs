using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.TagRequests.GetAll
{
    public class GetAllTagRequestHandler : IRequestHandler<GetAllTagRequest, IQueryable<Tag>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTagRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Tag>> Handle(GetAllTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.Tags.Where(x => x.TagGroupId == request.TagGroupId));
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Tag), $"Could not find tag with id: {request.TagGroupId} for {request.UserId} USER", e);
            }
        }
    }
}