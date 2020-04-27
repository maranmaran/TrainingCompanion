using Backend.Business.TrainingPrograms.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Create
{
    public class CreateTrainingProgramUserRequestHandler : IRequestHandler<CreateTrainingProgramUserRequest, TrainingProgramUser>
    {
        private readonly IApplicationDbContext _context;
        private readonly ITrainingProgramAssignService _assignService;

        public CreateTrainingProgramUserRequestHandler(
            IApplicationDbContext context,
            ITrainingProgramAssignService assignService)
        {
            _context = context;
            _assignService = assignService;
        }


        public async Task<TrainingProgramUser> Handle(CreateTrainingProgramUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var program = await GetProgram(request.ProgramId, cancellationToken);
                var user = await GetUser(request.UserId, cancellationToken);

                var programUser = await _assignService.Assign(program, user, request.StartDate, cancellationToken);

                return programUser;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(CreateTrainingProgramUserRequest), e);
            }
        }

        public async Task<TrainingProgram> GetProgram(Guid trainingProgramId,
            CancellationToken cancellationToken = default)
        {
            var program =
                await _context.TrainingPrograms

                    .Include(x => x.TrainingBlocks)
                    .ThenInclude(x => x.Days)
                    .ThenInclude(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.Sets)

                    .Include(x => x.TrainingBlocks)
                    .ThenInclude(x => x.Days)
                    .ThenInclude(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.ExerciseType)
                    .ThenInclude(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)

                    .FirstOrDefaultAsync(x => x.Id == trainingProgramId,
                        cancellationToken);

            if (program == null)
                throw new NotFoundException(nameof(TrainingProgram), trainingProgramId);

            return program;
        }

        public async Task<ApplicationUser> GetUser(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var user =
                await _context.Users.FirstOrDefaultAsync(x => x.Id == userId,
                    cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), userId);

            return user;
        }
    }
}