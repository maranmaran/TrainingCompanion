using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.TagGroupRequests.Update
{
    public class UpdateTagGroupRequestHandler :
        IRequestHandler<UpdateTagGroupRequest, TagGroup>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTagGroupRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TagGroup> Handle(UpdateTagGroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Entry(request.TagGroup).CurrentValues.SetValues(request.TagGroup);

                _context.TagGroups.Update(request.TagGroup); // update

                await _context.SaveChangesAsync(cancellationToken);

                return request.TagGroup;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Tag), e);
            }
        }
    }
}