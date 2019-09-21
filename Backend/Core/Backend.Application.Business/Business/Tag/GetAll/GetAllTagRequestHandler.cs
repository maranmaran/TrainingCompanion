using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Tag.GetAll
{
    public class GetAllTagRequestHandler : IRequestHandler<GetAllTagRequest, IQueryable<Domain.Entities.ExerciseType.Tag>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTagRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.ExerciseType.Tag>> Handle(GetAllTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.ExerciseProperties.Where(x => x.TagGroupId == request.TagGroupId));
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.Tag), $"Could not find tag with id: {request.TagGroupId} for {request.UserId} USER", e);
            }
        }
    }
}