using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Exercise.Update
{
    public class UpdateExerciseRequestHandler :
        IRequestHandler<UpdateExerciseRequest, UpdateExerciseRequestResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateExerciseRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateExerciseRequestResponse> Handle(UpdateExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //_context.Exercises.Attach(request.Exercise).CurrentValues.SetValues(request.Exercise);
                //_context.Exercises.Update(request.Exercise);

                //await _context.SaveChangesAsync(cancellationToken);

                //return new UpdateExerciseRequestResponse()
                //{
                //    Exercise = request.Exercise,
                //    AddedExercise = request.ExerciseAdd
                //};

                return new UpdateExerciseRequestResponse();
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Exercise), e);
            }
        }
    }
}