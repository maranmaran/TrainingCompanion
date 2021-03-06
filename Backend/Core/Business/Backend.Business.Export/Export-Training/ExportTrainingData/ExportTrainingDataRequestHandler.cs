﻿using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Export.ExportTrainingData
{
    public class ExportTrainingDataRequestHandler : IRequestHandler<ExportTrainingDataRequest, FileContentResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        //private readonly INotificationService _notificationService;
        //private readonly IExcelService _excelService;

        public ExportTrainingDataRequestHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<FileContentResult> Handle(ExportTrainingDataRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context.Users.Include(x => x.UserSetting).First(x => x.Id == request.UserId);
                var trainings = await GetTrainingData(request, cancellationToken);

                var exporter = new TrainingExporter
                {
                    User = user,
                    Columns = GetColumns(user, trainings),
                    Data = _mapper.Map<IEnumerable<ExportTrainingDto>>(trainings)
                };

                var fileResult = await exporter.Export();

                if (fileResult != null)
                {
                    // inform user through notification and email that export is done and
                    // provide link for payload inside notification download url.. ?
                    // notify..
                    //await _mediator.Publish(new (), cancellationToken);
                }

                return fileResult;
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

        private IEnumerable<string> GetExerciseTypeColumns(IEnumerable<ExerciseType> exerciseTypes)
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