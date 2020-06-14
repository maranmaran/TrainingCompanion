using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Exercises.TagRequests.Update
{
    public class UpdateTagRequestHandler :
        IRequestHandler<UpdateTagRequest, Tag>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTagRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Tag> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var propertyToUpdate = await _context.Tags.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (propertyToUpdate == null)
                    throw new NotFoundException(nameof(Tag), request.Id);

                _mapper.Map(request, propertyToUpdate);

                _context.Tags.Update(propertyToUpdate);

                await _context.SaveChangesAsync(cancellationToken);

                return propertyToUpdate;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Tag), e);
            }
        }
    }
}