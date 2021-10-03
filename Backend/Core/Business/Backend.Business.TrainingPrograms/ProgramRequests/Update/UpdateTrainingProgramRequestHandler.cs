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
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Update
{
    public class UpdateTrainingProgramRequestHandler : IRequestHandler<UpdateTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorage _storage;
        private readonly IMediaCompressionService _compressionService;

        public UpdateTrainingProgramRequestHandler(IApplicationDbContext context,
            IMapper mapper, IStorage storage, IMediaCompressionService compressionService)
        {
            _context = context;
            _mapper = mapper;
            _storage = storage;
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

            // TODO... outsource this logic somewhere to share...
            // TODO These media stuff goes on with user avatars, training media, exercise media, chat media, training program media
            if (request.Image != entity.ImageFtpFilePath && request.Image.Contains("data:image/jpeg;base64,"))
            {
                entity.ImageFtpFilePath = _storage.GetKey(nameof(TrainingProgram), entity.CreatorId);

                var file = new MemoryStream(Convert.FromBase64String(request.Image.Replace("data:image/jpeg;base64,", string.Empty)));

                var compressedFile = await _compressionService.Compress(MediaType.Image, file);

                //TODO: Delete previous image...
                await _storage.WriteAsync(entity.ImageFtpFilePath, compressedFile, "image/jpeg");

                entity.ImageUrl = await _storage.GetUrlAsync(entity.ImageFtpFilePath);
            }

            return entity;
        }
    }
}