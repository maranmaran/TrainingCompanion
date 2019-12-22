using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Excel.Models.Export;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExcelService
    {
        Task<ExportResult> Export(IExportDataContainer data, CancellationToken cancellationToken);
        Task<IEnumerable<T>> ParseImportData<T>(IFormFile file, CancellationToken cancellationToken);
    }

}
