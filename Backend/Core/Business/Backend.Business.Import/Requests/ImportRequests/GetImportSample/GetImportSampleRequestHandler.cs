using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Import.Models;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Business.Import.Requests.ImportRequests.GetImportSample
{
    public class GetImportSampleRequestHandler : IRequestHandler<GetImportSampleRequest, FileContentResult>
    {

        public async Task<FileContentResult> Handle(GetImportSampleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var fileBytes = await File.ReadAllBytesAsync($"{ GetSamplePath(request.ImportType, request.SampleType) }.xlsx", cancellationToken);
                const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // TODO: get from settings or something
                var title = request.SampleType + ".xlsx";

                return new FileContentResult(fileBytes, contentType)
                {
                    FileDownloadName = title
                };

            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetImportSampleRequest), e);
            }
        }

        public string GetSamplePath(ImportType importType, SampleType sampleType)
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                   $"/Business/Import/Samples/{importType}/{sampleType}";
        }
    }
}