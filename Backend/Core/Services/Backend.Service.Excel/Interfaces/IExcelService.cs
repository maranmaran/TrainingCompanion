﻿using Backend.Common;
using Backend.Service.Excel.Models.Export;
using Backend.Service.Excel.Models.Import;
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

        Task<IEnumerable<ValidationError>> ValidateData(IFormFile file, IList<ImportColumn> allowedColumns, CancellationToken cancellationToken);
    }
}