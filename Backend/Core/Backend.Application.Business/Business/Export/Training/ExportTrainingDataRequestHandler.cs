using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Export;
using Backend.Service.Excel.Models.Export.Training;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Export.Training
{
    public class ExportTrainingDataRequestHandler : IRequestHandler<ExportTrainingDataRequest, ExportResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        private readonly IExcelService _excelService;
        //private readonly INotificationService _notificationService;
        //private readonly IExcelService _excelService;

        public ExportTrainingDataRequestHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator, IExcelService excelService)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _excelService = excelService;
        }

        public async Task<ExportResult> Handle(ExportTrainingDataRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context.Users.Include(x => x.UserSetting).First(x => x.Id == request.UserId);
                var trainings = await GetTrainingData(request, cancellationToken);

                var exportData = new ExportTrainingDataContainer
                {
                    User = user,
                    Columns = GetColumns(user, trainings),
                    Trainings = _mapper.Map<IEnumerable<ExportTrainingDto>>(trainings)
                };

                var fileData = await _excelService.Export(exportData, cancellationToken);

                return fileData;

                // TODO: Make this asynchronous call completely and detach it from frontend
                // inform user through notification and email that export is done and provide link for payload inside notification download url.. ?
                //_notificationService.NotifyUser(new No)
            }
            catch (Exception e)
            {
                throw new Exception($"Could not export training data. {request.UserId}", e);
            }
        }

        private async Task<IEnumerable<Domain.Entities.TrainingLog.Training>> GetTrainingData(ExportTrainingDataRequest request, CancellationToken cancellationToken)
        {
            var nonFilteredData = _context.Trainings
                .Include(x => x.Exercises)
                .ThenInclude(x => x.ExerciseType)
                .ThenInclude(x => x.Properties)
                .ThenInclude(x => x.Tag)
                .ThenInclude(x => x.TagGroup)

                .Include(x => x.Exercises)
                .ThenInclude(x => x.Sets);

            var filteredData = nonFilteredData.Where(x => x.ApplicationUserId == request.UserId);

            if (request.DateFrom.HasValue)
                filteredData.Where(x => x.DateTrained.Date >= request.DateFrom.Value.Date);

            if (request.DateTo.HasValue)
                filteredData.Where(x => x.DateTrained.Date <= request.DateTo.Value.Date);

            return await filteredData.ToListAsync(cancellationToken);
        }

        private IEnumerable<string> GetColumns(ApplicationUser user, IEnumerable<Domain.Entities.TrainingLog.Training> trainings)
        {
            var columns = new List<string>()
            {
                "Date"
            };

            var exerciseTypes = trainings
                .SelectMany(x => x.Exercises.Select(x => x.ExerciseType)) // flatten
                .GroupBy(x => x.Id) // group by ID
                .Select(x => x.First()) // select only first values from each grouping (UNIQUE)
                .ToList();

            columns.AddRange(GetExerciseTypeColumns(exerciseTypes));

            columns.Add(user.UserSetting.RpeSystem == RpeSystem.Rpe ? "RPE" : "RIR");
            columns.Add("Volume");

            return columns;
        }

        private IEnumerable<string> GetExerciseTypeColumns(IEnumerable<Domain.Entities.ExerciseType.ExerciseType> exerciseTypes)
        {
            var columns = new List<string>()
            {
                "Exercise"
            };

            if (exerciseTypes.Any(x => x.RequiresWeight || x.RequiresBodyweight))
                columns.Add("Weight");

            if (exerciseTypes.Any(x => x.RequiresReps))
                columns.Add("Reps");

            if (exerciseTypes.Any(x => x.RequiresTime))
                columns.Add("Time");

            return columns;
        }
    }
}