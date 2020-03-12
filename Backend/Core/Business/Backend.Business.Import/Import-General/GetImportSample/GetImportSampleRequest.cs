using Backend.Business.Import.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Business.Import.GetImportSample
{
    public class GetImportSampleRequest : IRequest<FileContentResult>
    {
        public ImportType ImportType { get; set; }
        public SampleType SampleType { get; set; }
    }
}
