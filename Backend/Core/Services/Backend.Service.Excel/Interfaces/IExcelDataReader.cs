using System.Collections.Generic;
using OfficeOpenXml;

namespace Backend.Library.Excel.Interfaces
{
    public interface IExcelDataReader<T> where T : class
    {
        IEnumerable<T> ReadData(ExcelWorksheet sheet);
    }
}
