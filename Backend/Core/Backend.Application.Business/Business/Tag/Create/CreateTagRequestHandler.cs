using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Tag.Create
{
    public class CreateTagRequestHandler :
        IRequestHandler<CreateTagRequest, Domain.Entities.ExerciseType.Tag>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTagRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.Tag> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = _mapper.Map<Domain.Entities.ExerciseType.Tag>(request);

                _context.Tags.Add(tag);

                await _context.SaveChangesAsync(cancellationToken);

                return tag;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.Tag), e);
            }
        }
    }
}