using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Enum;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.MediaCompression.Interfaces;
using MediatR;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Create
{
    public class CreateTrainingProgramRequestHandler : IRequestHandler<CreateTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IS3Service _s3Service;
        private readonly IMediaCompressionService _compressionService;

        public CreateTrainingProgramRequestHandler(IApplicationDbContext context,
            IMapper mapper,
            IS3Service s3Service,
            IMediaCompressionService compressionService)
        {
            _context = context;
            _mapper = mapper;
            _s3Service = s3Service;
            _compressionService = compressionService;
        }


        public async Task<TrainingProgram> Handle(CreateTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<CreateTrainingProgramRequest, TrainingProgram>(request);

                entity = await SaveImage(request, entity);

                _context.TrainingPrograms.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingProgram), e);
            }
        }

        public async Task<TrainingProgram> SaveImage(CreateTrainingProgramRequest request, TrainingProgram entity)
        {
            if (string.IsNullOrWhiteSpace(request.Image))
            {
                entity.ImageFtpFilePath = null;
                entity.ImageUrl = null;
                return entity;
            }

            if (request.Image != entity.ImageFtpFilePath && request.Image.Contains("data:image/jpeg;base64,"))
            {
                entity.ImageFtpFilePath = GetS3Key(request);

                var file = new MemoryStream(Convert.FromBase64String(request.Image.Replace("data:image/jpeg;base64,", string.Empty)));

                var compressedFile = await _compressionService.Compress(MediaType.Image, file);

                await _s3Service.WriteToS3(entity.ImageFtpFilePath, compressedFile);

                entity.ImageUrl = await _s3Service.GetPresignedUrlAsync(entity.ImageFtpFilePath);
            }

            return entity;
        }

        public string GetS3Key(CreateTrainingProgramRequest request)
        {
            var builder = new StringBuilder();

            if (request.CreatorId != Guid.Empty)
                builder.Append($"training-program/{request.CreatorId}/{Guid.NewGuid()}");

            return builder.ToString();
        }
    }
}