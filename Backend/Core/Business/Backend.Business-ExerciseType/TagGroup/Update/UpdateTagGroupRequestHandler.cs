using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business_ExerciseType.TagGroup.Update
{
    public class UpdateTagGroupRequestHandler :
        IRequestHandler<UpdateTagGroupRequest, Domain.Entities.ExerciseType.TagGroup>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTagGroupRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.TagGroup> Handle(UpdateTagGroupRequest request, CancellationToken cancellationToken)
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
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.Tag), e);
            }
        }
    }
}