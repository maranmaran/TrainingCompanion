using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backend.Service.Excel.Models
{
    public class ExportResult
    {
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
    }
}
