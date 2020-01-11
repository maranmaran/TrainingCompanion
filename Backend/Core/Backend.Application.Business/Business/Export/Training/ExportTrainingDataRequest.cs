using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Application.Business.Business.Export.Training
{
    public class ExportTrainingDataRequest : IRequest<FileContentResult>
    {
        public Guid UserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}