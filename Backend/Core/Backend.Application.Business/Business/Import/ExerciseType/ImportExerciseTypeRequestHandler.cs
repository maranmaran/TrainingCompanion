using AutoMapper;
using Backend.Domain;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Import.ExerciseType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Import.ExerciseType
{
    public class ImportExerciseTypeRequestHandler : IRequestHandler<ImportExerciseTypeRequest, Unit>
    {
        private readonly IExcelService _excelService;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImportExerciseTypeRequestHandler(IExcelService excelService, IApplicationDbContext context, IMapper mapper)
        {
            _excelService = excelService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ImportExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dataRows = await _excelService.ParseImportData<ImportExerciseTypeDto>(request.File, cancellationToken);

                var importer = new ExerciseTypeImporter(_context, request.Userid, _mapper);

                await importer.DoImport(dataRows, cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import exercises.", e);
            }
        }
    }
}