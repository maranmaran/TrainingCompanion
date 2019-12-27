using AutoMapper;
using Backend.Domain;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Import;
using Backend.Service.Excel.Models.Import.ExerciseType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Import.ExerciseType
{
    public class ImportExerciseTypeRequestHandler : IRequestHandler<ImportExerciseTypeRequest, ImportExerciseTypeResponse>
    {
        private readonly IExcelService _excelService;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IList<ImportColumn> _importColumns;

        public ImportExerciseTypeRequestHandler(IExcelService excelService, IApplicationDbContext context, IMapper mapper)
        {
            _excelService = excelService;
            _context = context;
            _mapper = mapper;

            _importColumns = typeof(ImportExerciseTypeColumns)
                                .GetFields(BindingFlags.Static | BindingFlags.Public)
                                .Select(x => x.GetValue(null))
                                .Cast<ImportColumn>()
                                .ToList();
        }

        public async Task<ImportExerciseTypeResponse> Handle(ImportExerciseTypeRequest request, CancellationToken cancellationToken)
        {

            try
            {
                // validate
                var validationErrors = await _excelService.ValidateData(request.File, _importColumns, cancellationToken);

                var response = new ImportExerciseTypeResponse(validationErrors);
                if (validationErrors != null)
                {
                    return response;
                }

                // parse imported data to data structure
                var dataRows = await _excelService.ParseImportData<ImportExerciseTypeDto>(request.File, cancellationToken);

                // call imported and do work
                var importer = new ExerciseTypeImporter(_context, request.Userid, _mapper);
                await importer.DoImport(dataRows, cancellationToken);

                return response;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import exercises.", e);
            }
        }
    }
}