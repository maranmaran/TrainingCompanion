using Backend.Service.Import.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Application.Business.Business.Import.GetImportSample
{
    public class GetImportSampleRequest : IRequest<FileContentResult>
    {
        public ImportType ImportType { get; set; }
        public SampleType SampleType { get; set; }
    }
}
