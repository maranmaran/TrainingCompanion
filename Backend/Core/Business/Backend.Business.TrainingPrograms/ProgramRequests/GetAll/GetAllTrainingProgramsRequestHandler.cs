using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.GetAll
{
    public class GetAllTrainingProgramsRequestHandler : IRequestHandler<GetAllTrainingProgramsRequest, IEnumerable<TrainingProgram>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingProgramsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TrainingProgram>> Handle(GetAllTrainingProgramsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _context.TrainingPrograms.Where(x => x.CreatorId == request.CreatorId)
                    .ToListAsync(cancellationToken);

                return entities;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetAllTrainingProgramsRequest), e);
            }
        }
    }
}