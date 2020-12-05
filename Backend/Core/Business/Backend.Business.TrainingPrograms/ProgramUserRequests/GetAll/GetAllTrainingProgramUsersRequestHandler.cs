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
        private readonly IS3Service _s3Service;

        public GetAllTrainingProgramUsersRequestHandler(IApplicationDbContext context, IS3Service s3Service)
        {
            _context = context;
            _s3Service = s3Service;
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
                user.User.Avatar = await _s3Service.GetPresignedUrlAsync(user.User.Avatar);
            }
        }
    }
}