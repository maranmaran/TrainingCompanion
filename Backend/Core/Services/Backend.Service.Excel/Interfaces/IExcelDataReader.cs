using OfficeOpenXml;
using System.Collections.Generic;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExcelDataReader<T> where T : class
    {
        IEnumerable<T> ReadData(ExcelWorksheet sheet);
    }
}
