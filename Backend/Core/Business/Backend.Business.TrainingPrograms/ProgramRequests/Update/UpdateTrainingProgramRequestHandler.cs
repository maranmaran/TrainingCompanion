using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Enum;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.MediaCompression.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Update
{
    public class UpdateTrainingProgramRequestHandler : IRequestHandler<UpdateTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IS3Service _s3Service;
        private readonly IMediaCompressionService _compressionService;

        public UpdateTrainingProgramRequestHandler(IApplicationDbContext context,
            IMapper mapper, IS3Service s3Service, IMediaCompressionService compressionService)
        {
            _context = context;
            _mapper = mapper;
            _s3Service = s3Service;
            _compressionService = compressionService;
        }


        public async Task<TrainingProgram> Handle(UpdateTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, entity);

                entity = await SaveImage(request, entity);

                _context.TrainingPrograms.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(UpdateTrainingProgramRequest), e);
            }
        }

        public async Task<TrainingProgram> SaveImage(UpdateTrainingProgramRequest request, TrainingProgram entity)
        {
            if (string.IsNullOrWhiteSpace(request.Image))
            {
                entity.ImageFtpFilePath = null;
                entity.ImageUrl = null;
                return entity;
            }

            var base64Prefixes = new[]
            {
                "data:image/jpeg;base64,",
                "data:image/png;base64,",
            };

            // TODO... outsource this logic somewhere to share...
            // TODO These media stuff goes on with user avatars, training media, exercise media, chat media, training program media
            if (request.Image != entity.ImageFtpFilePath && base64Prefixes.Any(prefix => request.Image.Contains(prefix)))
            {
                entity.ImageFtpFilePath = _s3Service.GetS3Key(nameof(TrainingProgram), entity.CreatorId);

                base64Prefixes.ForAll(x => request.Image = request.Image.Replace(x, string.Empty));

                var file = new MemoryStream(Convert.FromBase64String(request.Image));

                var compressedFile = await _compressionService.Compress(MediaType.Image, file);

                //TODO: Delete previous image...
                await _s3Service.WriteToS3(entity.ImageFtpFilePath, compressedFile);

                entity.ImageUrl = await _s3Service.GetPresignedUrlAsync(entity.ImageFtpFilePath);
            }

            return entity;
        }

    }
}