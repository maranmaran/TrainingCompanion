using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Set.Update
{
    public class UpdateSetRequestHandler :
        IRequestHandler<UpdateSetRequest, UpdateSetRequestResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateSetRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateSetRequestResponse> Handle(UpdateSetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //_context.Sets.Attach(request.Set).CurrentValues.SetValues(request.Set);
                //_context.Sets.Update(request.Set);

                //await _context.SaveChangesAsync(cancellationToken);

                //return new UpdateSetRequestResponse()
                //{
                //    Set = request.Set,
                //    AddedSet = request.SetAdd
                //};

                return new UpdateSetRequestResponse();
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Set), e);
            }
        }
    }
}