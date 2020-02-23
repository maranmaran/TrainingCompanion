using AutoMapper;
using Backend.Application.Business.Extensions;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Exercise.UpdateMany
{
    public class UpdateManyExercisesRequestHandler : IRequestHandler<UpdateManyExercisesRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateManyExercisesRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateManyExercisesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // to remove all virtual props
                var exercises = request.Exercises.Select(x => x.NullfyVirtualProperties());

                foreach (var entity in exercises)
                {
                    _context.Exercises.Update(entity);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(UpdateManyExercisesRequest), e);
            }
        }
    }
}