using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Business.Export.ExportRequests.Training
{
    public class ExportTrainingDataRequest : IRequest<FileContentResult>
    {
        public Guid UserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}