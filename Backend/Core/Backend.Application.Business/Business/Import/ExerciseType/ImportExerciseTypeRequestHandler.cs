using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Import.ExerciseType;
using Backend.Service.Excel.Models.Import.Training;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Import.ExerciseType
{
    public class ImportExerciseTypeRequestHandler : IRequestHandler<ImportExerciseTypeRequest, Unit>
    {
        private readonly IExcelService _excelService;
        private readonly IApplicationDbContext _context;

        public ImportExerciseTypeRequestHandler(IExcelService excelService, IApplicationDbContext context)
        {
            _excelService = excelService;
            _context = context;
        }

        public async Task<Unit> Handle(ImportExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dataRows = await _excelService.ParseImportData<ImportExerciseTypeDto>(request.File, cancellationToken);
                var existingExerciseTypes = _context.ExerciseTypes.Where(x => x.ApplicationUserId == request.Userid).AsNoTracking();

                var exerciseTypes = ParseImportData(dataRows, existingExerciseTypes, request.Userid);

                _context.ExerciseTypes.UpdateRange(exerciseTypes);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import training.", e);
            }
        }

        private IEnumerable<Domain.Entities.ExerciseType.ExerciseType> ParseImportData(
            IEnumerable<ImportExerciseTypeDto> data, 
            IEnumerable<Domain.Entities.ExerciseType.ExerciseType> existingTypes, 
            Guid userId)
        {
            var exerciseTypes = data.Select(x =>
            {
                var existingType = existingTypes.FirstOrDefault(y => y.Code == x.Code);
                var result = new Domain.Entities.ExerciseType.ExerciseType();

                if (existingType != null)
                    result = existingType;

                result.Active = x.Active;
                result.Name = x.Name;
                result.Code = x.Code;
                result.RequiresBodyweight = x.RequiresBodyweight;
                result.RequiresSets = x.RequiresSets;
                result.RequiresWeight = x.RequiresWeight;
                result.RequiresTime = x.RequiresTime;
                result.RequiresReps = x.RequiresReps;
                result.ApplicationUserId = userId;

                return result;
            });

            return exerciseTypes;
        }
    }
}