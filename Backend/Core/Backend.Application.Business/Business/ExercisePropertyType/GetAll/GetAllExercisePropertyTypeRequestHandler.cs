using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExercisePropertyType.GetAll
{
    public class GetAllExercisePropertyTypeRequestHandler : IRequestHandler<GetAllExercisePropertyTypeRequest, IQueryable<Domain.Entities.ExerciseType.ExercisePropertyType>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExercisePropertyTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.ExerciseType.ExercisePropertyType>> Handle(GetAllExercisePropertyTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.ExercisePropertyTypes.Include(x => x.Properties).Where(x => x.ApplicationUserId == request.ApplicationUserId));
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), $"Could not find exercise types for user with id: {request.ApplicationUserId} ", e);
            }
        }
    }
}