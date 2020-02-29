using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business_ExerciseType.Tag.Update
{
    public class UpdateTagRequestHandler :
        IRequestHandler<UpdateTagRequest, Domain.Entities.ExerciseType.Tag>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTagRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.Tag> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var propertyToUpdate = await _context.Tags.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, propertyToUpdate);

                _context.Tags.Update(propertyToUpdate);

                await _context.SaveChangesAsync(cancellationToken);

                return propertyToUpdate;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.Tag), e);
            }
        }
    }
}