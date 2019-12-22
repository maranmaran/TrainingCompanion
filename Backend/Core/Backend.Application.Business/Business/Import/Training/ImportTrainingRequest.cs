using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Excel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Business.Business.Import.Training
{
    public class ImportTrainingRequest: IRequest
    {
        public IFormFile File { get; set; }
    }

    public class ImportTrainingRequestHandler : IRequestHandler<ImportTrainingRequest, Unit>
    {
        private readonly IExcelService _excelService;

        public ImportTrainingRequestHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public async Task<Unit> Handle(ImportTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _excelService.Import(request.File, cancellationToken);
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import training.", e);
            }
        }
    }
}
