using Backend.Service.Excel.Models.Export;
using MediatR;
using System;

namespace Backend.Application.Business.Business.Export.Training
{
    public class ExportTrainingDataRequest : IRequest<ExportResult>
    {
        public Guid UserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}