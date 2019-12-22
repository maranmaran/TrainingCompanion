using System.IO;

namespace Backend.Service.Excel.Models.Export
{
    public class ExportResult
    {
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
    }
}
