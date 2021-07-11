using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Business.Export
{
    public static class ExcelUtils
    {
        public static ExcelWorkbook SetProperties(this ExcelWorkbook book, (string Title, string Author, string Comments, string Company) props)
        {
            book.Properties.Title = props.Title;
            book.Properties.Author = props.Author;
            book.Properties.Comments = props.Comments;
            book.Properties.Company = props.Company;

            return book;
        }

        public static async Task<Stream> GetResultStream(this ExcelPackage package)
        {
            package.Stream.Position = 0;

            var resultStream = new MemoryStream();
            await package.Stream.CopyToAsync(resultStream);
            resultStream.Position = 0;

            return resultStream;
        }
    }
}