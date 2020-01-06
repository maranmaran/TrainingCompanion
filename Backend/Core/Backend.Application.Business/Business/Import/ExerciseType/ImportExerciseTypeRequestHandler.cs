using AutoMapper;
using Backend.Application.Business.Business.PushNotification.CreatePushNotification;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Import;
using Backend.Service.Excel.Models.Import.ExerciseType;
using Backend.Service.Logging.Interfaces;
using Backend.Service.PushNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;
        private readonly ILoggingService _loggingService;

        public ImportExerciseTypeRequestHandler(IExcelService excelService, IApplicationDbContext context, IMapper mapper, INotificationService notificationService, IMediator mediator, ILoggingService loggingService)
        {
            _excelService = excelService;
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
            _mediator = mediator;
            _loggingService = loggingService;

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

                await SendNotification(response, request.Userid, cancellationToken);

                return response;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import exercises.", e);
            }
        }

        private async Task SendNotification(ImportExerciseTypeResponse response, Guid receiverId, CancellationToken cancellationToken)
        {
            try
            {
                // save to db
                var payload = response.Success
                    ? "Exercise types import finished successfully!"
                    : "Exercise type import finished with errors. Check import page for more details";

                var notification = await _mediator.Send(new CreatePushNotificationRequest(NotificationType.ImportFinished, payload, receiverId), CancellationToken.None);

                await _notificationService.NotifyUser(notification, notification.Receiver.UserSetting.NotificationSettings,
                    CancellationToken.None);
            }
            catch (Exception e)
            {
                await _loggingService.LogError((int)HttpStatusCode.InternalServerError, e.Message, e.InnerException?.Message,
                    CancellationToken.None);
            }
        }


    }
}