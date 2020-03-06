﻿using Backend.Business.Import.Models.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Business.Import.Requests.ImportRequests.GetImportSample
{
    public class GetImportSampleRequest : IRequest<FileContentResult>
    {
        public ImportType ImportType { get; set; }
        public SampleType SampleType { get; set; }
    }
}
