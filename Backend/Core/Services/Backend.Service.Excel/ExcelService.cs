using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Common;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

namespace Backend.Service.Excel
{
    public class ExcelService: IExcelService
    {
        public async Task<ExportResult> Export(IExportDataContainer data)
        {
            var properties = data.GetExportFileProperties();
            
            using var package = new ExcelPackage(new MemoryStream());
            var workbook = package.Workbook.SetProperties(properties);
            var worksheet = workbook.Worksheets.Add(properties.Title);
            var styles = workbook.GetExportTrainingDataColumnNamedStyle();

            data.WriteToSheet(worksheet, styles);
         
            worksheet.Calculate();
            worksheet.Cells.AutoFitColumns();

            package.Save();

            return new ExportResult {
                Stream = await package.GetResultStream(), 
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                Title = properties.Title
            };
        }

    }
}
