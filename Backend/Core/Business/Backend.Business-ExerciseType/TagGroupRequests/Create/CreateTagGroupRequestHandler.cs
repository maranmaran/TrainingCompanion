using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.TagGroupRequests.Create
{
    public class CreateTagGroupRequestHandler : IRequestHandler<CreateTagGroupRequest, TagGroup>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTagGroupRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TagGroup> Handle(CreateTagGroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<TagGroup>(request);

                await _context.TagGroups.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Tag), e);
            }
        }
    }
}