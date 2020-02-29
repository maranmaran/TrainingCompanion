using Backend.Service.Excel.Interfaces;

namespace Backend.Service.Excel
{
    public class ExcelService : IExcelService
    {
        //public async Task<FileContentResult> Export(IExportDataContainer data, CancellationToken cancellationToken)
        //{
        //    var properties = data.GetExportFileProperties();

        //    using var package = new ExcelPackage(new MemoryStream());
        //    var workbook = package.Workbook.SetProperties(properties);
        //    var worksheet = workbook.Worksheets.Add(properties.Title);
        //    var styles = workbook.GetExportTrainingDataColumnNamedStyle();

        //    data.WriteToSheet(worksheet, styles);

        //    worksheet.Calculate();
        //    worksheet.Cells.AutoFitColumns();

        //    package.Save();

        //    var resultStream = await package.GetResultStream();
        //    const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // TODO: get from settings or something

        //    return new FileContentResult(await resultStream.ToByteArray(cancellationToken: cancellationToken), contentType)
        //    {
        //        FileDownloadName = properties.Title
        //    };
        //}

        //public async Task<IEnumerable<T>> ParseImportData<T>(IFormFile file, CancellationToken cancellationToken) where T : new()
        //{
        //    await using var stream = new MemoryStream();
        //    file.CopyTo(stream);

        //    using var package = new ExcelPackage(stream);
        //    var worksheet = package.Compatibility.IsWorksheets1Based
        //        ? package.Workbook.Worksheets[1]
        //        : package.Workbook.Worksheets[0];

        //    //return worksheet.ConvertSheetToObjects<T>();
        //    return null;
        //}

        //public async Task<IEnumerable<ValidationError>> ValidateData(IFormFile file, IList<ImportColumn> allowedColumns, CancellationToken cancellationToken)
        //{
        //    return null; // TODO
        //}
    }
}