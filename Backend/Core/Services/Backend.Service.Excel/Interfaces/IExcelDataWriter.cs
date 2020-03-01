using OfficeOpenXml;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExcelDataWriter
    {
        (string Title, string Author, string Comments, string Company) GetProperties();

        void Write(ExcelWorksheet sheet);
    }
}
