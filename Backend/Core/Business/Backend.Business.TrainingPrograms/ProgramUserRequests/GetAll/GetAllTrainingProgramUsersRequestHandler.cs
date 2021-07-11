using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.GetAll
{
    public class GetAllTrainingProgramUsersRequestHandler : IRequestHandler<GetAllTrainingProgramUsersRequest, IEnumerable<TrainingProgramUser>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorage _storage;

        public GetAllTrainingProgramUsersRequestHandler(IApplicationDbContext context, IStorage storage)
        {
            _context = context;
            _storage = storage;
        }

        public async Task<IEnumerable<TrainingProgramUser>> Handle(GetAllTrainingProgramUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var programUsers = await _context.TrainingProgramUsers
                    .Include(x => x.User)
                    .Where(x => x.TrainingProgramId == request.ProgramId).ToListAsync(cancellationToken);

                await RefreshAvatars(programUsers);

                return programUsers;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetAllTrainingProgramUsersRequest), e);
            }
        }

        private async Task RefreshAvatars(IEnumerable<TrainingProgramUser> programUsers)
        {
            foreach (var user in programUsers)
            {
                user.User.Avatar = await _storage.GetUrlAsync(user.User.Avatar);
            }
        }
    }
}