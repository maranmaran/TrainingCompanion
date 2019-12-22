using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Excel.Models.Export;
using Microsoft.AspNetCore.Http;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExcelService
    {
        Task<ExportResult> Export(IExportDataContainer data, CancellationToken cancellationToken);
        Task Import(IFormFile file, CancellationToken cancellationToken);
    }

}
