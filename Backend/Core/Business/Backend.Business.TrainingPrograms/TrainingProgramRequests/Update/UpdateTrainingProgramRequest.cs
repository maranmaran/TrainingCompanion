using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Update
{

    public class UpdateTrainingProgramRequest : IRequest<TrainingProgram>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class UpdateTrainingProgramRequestHandler : IRequestHandler<UpdateTrainingProgramRequest, TrainingProgram>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingProgramRequestHandler(IApplicationDbContext context,
                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<TrainingProgram> Handle(UpdateTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, entity);

                _context.TrainingPrograms.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(UpdateTrainingProgramRequest), e);
            }
        }
    }

}
