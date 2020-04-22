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

namespace Backend.Business.TrainingPrograms.ProgramRequests.GetAll
{
    public class GetAllTrainingProgramsRequestHandler : IRequestHandler<GetAllTrainingProgramsRequest, IEnumerable<TrainingProgram>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3Service;

        public GetAllTrainingProgramsRequestHandler(IApplicationDbContext context, IS3Service s3Service)
        {
            _context = context;
            _s3Service = s3Service;
        }


        public async Task<IEnumerable<TrainingProgram>> Handle(GetAllTrainingProgramsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _context.TrainingPrograms.Where(x => x.CreatorId == request.CreatorId)
                    .ToListAsync(cancellationToken);


                await RefreshImages(entities);

                return entities;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetAllTrainingProgramsRequest), e);
            }
        }

        public async Task RefreshImages(IEnumerable<TrainingProgram> entities)
        {
            foreach (var entity in entities)
            {
                if (_s3Service.CheckIfPresignedUrlIsExpired(entity.ImageUrl))
                {
                    entity.ImageUrl = await _s3Service.GetPresignedUrlAsync(entity.ImageFtpFilePath);
                }
            }
        }
    }
}