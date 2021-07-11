using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequestHandler : IRequestHandler<CreatePersonalBestRequest, Domain.Entities.ProgressTracking.PersonalBest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreatePersonalBestRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ProgressTracking.PersonalBest> Handle(CreatePersonalBestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //var exerciseType = await GetExerciseType(request.ExerciseTypeId, cancellationToken);

                var entity = _mapper.Map<PersonalBest>(request);

                // do transformations for unit systems
                TransformValuesToMetricSystem(entity, request.UnitSystem);
                // like wilks or ipf points
                CalculateStatistics(entity);

                _context.PBs.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(CreatePersonalBestRequest), e);
            }
        }

        ///// <summary>
        ///// Gets exercise type for personal best record
        ///// TODO: Handler exists for this however it has overhead of data
        ///// TODO: We need to reuse it but implement something that blocks extra data fetching as it's expensive
        ///// </summary>
        //internal async Task<ExerciseType> GetExerciseType(Guid id, CancellationToken cancellationToken)
        //{
        //    var type = await _context.ExerciseTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        //    if (type == null)
        //        throw new NotFoundException(nameof(ExerciseType), $"Exercise type not found for new PB record id: {id}");

        //    return type;
        //}

        /// <summary>
        /// Calculates and sets properties like wilks score or ipf points
        /// </summary>
        private void CalculateStatistics(PersonalBest entity)
        {
            // TODO IMPLEMENT CALCULATORS FOR THIS
        }

        /// <summary>
        /// Transforms all relevant values to metric system for DB
        /// </summary>
        private void TransformValuesToMetricSystem(PersonalBest entity, UnitSystem unitSystem)
        {
            entity.Value = entity.Value.ToMetricSystem(unitSystem);
            entity.Bodyweight = entity.Bodyweight?.ToMetricSystem(unitSystem);
        }
    }
}