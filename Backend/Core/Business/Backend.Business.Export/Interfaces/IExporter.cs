using Backend.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style.XmlAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Business.Export.Interfaces
{
    public interface IExporter<T> where T : class
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<string> Columns { get; set; }

        Task<FileContentResult> Export();

        (string Title, string Author, string Comments, string Company) GetExportFileProperties();

        void WriteToSheet(ExcelWorksheet sheet, (ExcelNamedStyleXml HeaderStyle, ExcelNamedStyleXml CellStyle) styles);
    }
}