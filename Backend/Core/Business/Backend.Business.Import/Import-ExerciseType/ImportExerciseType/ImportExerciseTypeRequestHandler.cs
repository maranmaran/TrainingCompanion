using AutoMapper;
using Backend.Business.Notifications.PushNotificationRequests.CreatePushNotification;
using Backend.Business.Notifications.PushNotificationRequests.NotifyUser;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Library.Logging.Interfaces;
using MediatR;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Import.ImportExerciseType
{
    public class ImportExerciseTypeRequestHandler : IRequestHandler<ImportExerciseTypeRequest, ImportExerciseTypeResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggingService _loggingService;

        public ImportExerciseTypeRequestHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator,
            ILoggingService loggingService)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _loggingService = loggingService;
        }

        public async Task<ImportExerciseTypeResponse> Handle(ImportExerciseTypeRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var result = new ImportExerciseTypeResponse(true);
                using (var package = new ExcelPackage(request.File.OpenReadStream()))
                {
                    var worksheet = package.Compatibility.IsWorksheets1Based
                                ? package.Workbook.Worksheets[1]
                                : package.Workbook.Worksheets[0];

                    List<ExerciseTypeImportDto> importData;
                    try
                    {
                        importData = worksheet.ConvertSheetToObjects<ExerciseTypeImportDto>().ToList();
                    }
                    catch (Exception e)
                    {
                        result.AddError(e.Message);
                        return result;
                    }

                    // call imported and do work
                    try
                    {
                        var importer = new ExerciseTypeImporter(_context, request.Userid, _mapper);
                        await importer.DoImport(importData, cancellationToken);
                    }
                    catch (Exception e)
                    {
                        result.AddError(e.Message);
                        return result;
                    }
                }

                await SendNotification(result, request.Userid, cancellationToken);

                return result;
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

                await _mediator.Publish(new NotifyUserNotification(notification, notification.Receiver.UserSetting.NotificationSettings), cancellationToken);
            }
            catch (Exception e)
            {
                await _loggingService.LogError((int)HttpStatusCode.InternalServerError, e.Message, e.InnerException?.Message,
                    CancellationToken.None);
            }
        }


    }
}