namespace Backend.Library.Excel
{
    //public class ExcelService : IExcelService
    //{
    //    public async Task<FileContentResult> Export(IExcelDataWriter writer, CancellationToken cancellationToken)
    //    {
    //        var properties = writer.GetProperties();

    //        using var package = new ExcelPackage(new MemoryStream());
    //        var workbook = package.Workbook.SetProperties(properties);
    //        var worksheet = workbook.Worksheets.Add(properties.Title);

    //        writer.Write(worksheet);

    //        worksheet.Calculate();
    //        worksheet.Cells.AutoFitColumns();

    //        package.Save();

    //        var resultStream = await package.GetResultStream();
    //        const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // TODO: get from settings or something

    //        return new FileContentResult(await resultStream.ToByteArray(cancellationToken: cancellationToken), contentType)
    //        {
    //            FileDownloadName = properties.Title
    //        };
    //    }

    //    public async Task<IEnumerable<T>> ParseData<T>(IFormFile file, IExcelDataReader<T> reader, CancellationToken cancellationToken) where T : class
    //    {
    //        await using var stream = new MemoryStream();
    //        file.CopyTo(stream);

    //        using var package = new ExcelPackage(stream);
    //        var worksheet = package.Compatibility.IsWorksheets1Based
    //            ? package.Workbook.Worksheets[1]
    //            : package.Workbook.Worksheets[0];

    //        return reader.ReadData(worksheet);
    //    }
    //}
}