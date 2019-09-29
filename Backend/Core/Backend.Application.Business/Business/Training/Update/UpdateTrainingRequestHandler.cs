namespace Backend.Application.Business.Business.Training.Update
{
    //TODO REMOVE
    //public class UpdateTrainingRequestHandler :
    //    IRequestHandler<UpdateTrainingRequest, UpdateTrainingRequestResponse>
    //{
    //    private readonly IApplicationDbContext _context;
    //    private readonly IMapper _mapper;

    //    public UpdateTrainingRequestHandler(IApplicationDbContext context, IMapper mapper)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    //public async Task<UpdateTrainingRequestResponse> Handle(UpdateTrainingRequest request, CancellationToken cancellationToken)
    //    //{
    //    //    //try
    //    //    //{

    //    //    //    foreach (var exercise in request.Training.Exercises)
    //    //    //    {
    //    //    //        // don't manipulate type
    //    //    //        var type = await _context
    //    //    //            .ExerciseTypes
    //    //    //            .Include(x => x.Properties)
    //    //    //            .ThenInclude(x => x.Tag)
    //    //    //            .ThenInclude(x => x.TagGroup)
    //    //    //            .FirstAsync(x => x.Id == exercise.ExerciseTypeId, cancellationToken);

    //    //    //        _context.Entry(type).State = EntityState.Detached;
    //    //    //        exercise.ExerciseType = type;

    //    //    //        foreach (var set in exercise.Sets)
    //    //    //        {
    //    //    //            // update additional properties
    //    //    //            if (type.RequiresReps && type.RequiresSets)
    //    //    //            {
    //    //    //                if (type.RequiresWeight)
    //    //    //                {
    //    //    //                    set.Volume = set.Reps * set.Weight;
    //    //    //                }
    //    //    //                else if (type.RequiresBodyweight)
    //    //    //                {
    //    //    //                    // bw
    //    //    //                }
    //    //    //            }
    //    //    //            _context.Sets.Update(set);
    //    //    //        }
    //    //    //        _context.Exercises.Update(exercise);
    //    //    //    }

    //    //    //    _context.Trainings.Update(request.Training);

    //    //    //    await _context.SaveChangesAsync(cancellationToken);

    //    //    //    return new UpdateTrainingRequestResponse()
    //    //    //    {
    //    //    //        Training = request.Training,
    //    //    //    };
    //    //    //}
    //    //    //catch (Exception e)
    //    //    //{
    //    //    //    throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
    //    //    //}
    //    //}
    //}
}