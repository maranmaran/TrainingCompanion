using Backend.Service.Excel.Models.Export;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExcelService
    {
        Task<ExportResult> Export(IExportDataContainer data, CancellationToken cancellationToken);

        Task<IEnumerable<T>> ParseImportData<T>(IFormFile file, CancellationToken cancellationToken) where T : new();
    }
}