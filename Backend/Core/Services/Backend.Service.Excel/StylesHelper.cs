using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;

namespace Backend.Service.Excel
{
    public static class StylesHelper
    {

        public static (ExcelNamedStyleXml HeaderStyles, ExcelNamedStyleXml DataCellStyles) GetExportTrainingDataColumnNamedStyle(this ExcelWorkbook book)
        {
            var style = book.Styles.CreateNamedStyle("TrainingCellStyle");
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return (style, style);
        }
    }
}
