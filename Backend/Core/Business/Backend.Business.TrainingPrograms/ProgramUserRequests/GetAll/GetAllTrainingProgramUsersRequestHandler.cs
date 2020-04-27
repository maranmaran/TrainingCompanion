using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.GetAll
{
    public class GetAllTrainingProgramUsersRequestHandler : IRequestHandler<GetAllTrainingProgramUsersRequest, IEnumerable<TrainingProgramUser>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingProgramUsersRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TrainingProgramUser>> Handle(GetAllTrainingProgramUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var programUsers = await _context.TrainingProgramUsers
                    .Include(x => x.User)
                    .Where(x => x.TrainingProgramId == request.ProgramId).ToListAsync(cancellationToken);
                return programUsers;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetAllTrainingProgramUsersRequest), e);
            }
        }
    }
}