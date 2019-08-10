using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Coaches.GetAllCoaches
{
    public class GetAllCoachsRequestHandler : IRequestHandler<GetAllCoachsRequest, IQueryable<Coach>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCoachsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Coach>> Handle(GetAllCoachsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_context.Coaches);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Coach), e);
            }
        }
    }
}
