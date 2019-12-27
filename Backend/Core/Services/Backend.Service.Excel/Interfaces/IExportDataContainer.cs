﻿using OfficeOpenXml;
using OfficeOpenXml.Style.XmlAccess;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExportDataContainer
    {
        (string Title, string Author, string Comments, string Company) GetExportFileProperties();

        void WriteToSheet(ExcelWorksheet sheet, (ExcelNamedStyleXml HeaderStyle, ExcelNamedStyleXml CellStyle) styles);

    }
}