using System.IO;

namespace Backend.Business.Export.Models
{
    public class ExportResult
    {
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
    }
}