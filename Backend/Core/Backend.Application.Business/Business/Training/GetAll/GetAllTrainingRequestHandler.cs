using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Business.Business.ExerciseType.GetAll;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Training.GetAll
{
    public class GetAllTrainingRequestHandler : IRequestHandler<GetAllTrainingRequest, IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.TrainingLog.Training>> Handle(GetAllTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainings = _context.Trainings;


                return Task.FromResult(trainings.AsQueryable());
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.UserId} USER", e);
            }
        }
    }
}