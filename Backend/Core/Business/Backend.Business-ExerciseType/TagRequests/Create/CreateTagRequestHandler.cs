using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.TagRequests.Create
{
    public class CreateTagRequestHandler :
        IRequestHandler<CreateTagRequest, Tag>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTagRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Tag> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = _mapper.Map<Tag>(request);

                _context.Tags.Add(tag);

                await _context.SaveChangesAsync(cancellationToken);

                return tag;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Tag), e);
            }
        }
    }
}