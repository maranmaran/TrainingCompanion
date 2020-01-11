using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Application.Business.Business.Import.GetImportSample
{
    public class GetImportSampleRequestHandler : IRequestHandler<GetImportSampleRequest, FileContentResult>
    {
        public async Task<FileContentResult> Handle(GetImportSampleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var fileBytes = await File.ReadAllBytesAsync($"./Samples/{request.ImportType}/{request.SampleType}.xlsx", cancellationToken);
                const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // TODO: get from settings or something
                var title = request.SampleType;

                return new FileContentResult(fileBytes, contentType)
                {
                    FileDownloadName = title.ToString()
                };

            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetImportSampleRequest), e);
            }
        }
    }
}