using Backend.Business.Export.Interfaces;
using Backend.Common;
using Backend.Common.Extensions;
using Backend.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Business.Export
{
    public class TrainingExporter : IExporter<ExportTrainingDto>
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ExportTrainingDto> Data { get; set; }
        public IEnumerable<string> Columns { get; set; }

        public async Task<FileContentResult> Export()
        {
            var properties = GetExportFileProperties();

            using var package = new ExcelPackage(new MemoryStream());
            var workbook = package.Workbook.SetProperties(properties);
            var worksheet = workbook.Worksheets.Add(properties.Title);

            WriteToSheet(worksheet, GetExportColumnNamedStyle(workbook));

            worksheet.Calculate();
            worksheet.Cells.AutoFitColumns();

            package.Save();

            var resultStream = await package.GetResultStream();
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // TODO: get from settings or something

            return new FileContentResult(await resultStream.ToByteArray(), contentType)
            {
                FileDownloadName = properties.Title
            };
        }

        public static (ExcelNamedStyleXml HeaderStyles, ExcelNamedStyleXml DataCellStyles) GetExportColumnNamedStyle(ExcelWorkbook book)
        {
            var style = book.Styles.CreateNamedStyle("TrainingCellStyle");
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return (style, style);
        }

        public (string Title, string Author, string Comments, string Company) GetExportFileProperties()
        {
            return (
                Title: $"{User.FullName} - Training data",
                Author: $"{User.FullName}", //TODO
                Comments: "Training report from - to... or entire report", // TODO
                Company: "Training companion d.o.o"
            );
        }

        public void WriteToSheet(ExcelWorksheet sheet, (ExcelNamedStyleXml HeaderStyle, ExcelNamedStyleXml CellStyle) styles)
        {
            var indexes = (
                FromColumn: 1,
                ToColumn: Columns.Count(),
                Row: 1,
                Cell: 1,
                ToRow: -1
            );

            foreach (var (training, index) in Data.WithIndex())
            {
                indexes.ToRow = training.Exercises.Aggregate(0, (acc, cur) => acc += cur.Sets.Count());

                CreateTable(sheet, indexes, $"Table{index}", styles);

                foreach (var column in Columns)
                {
                    sheet.Cells[indexes.Row, indexes.Cell++].Value = column.ToUpper();
                }

                indexes.Row += 1;
                indexes.Cell = 1;

                sheet.Cells[indexes.Row, indexes.Cell++].Value = training.Date?.ToString("dd/MM/yyyy");

                foreach (var exercise in training.Exercises)
                {
                    sheet.Cells[indexes.Row, indexes.Cell++].Value = exercise.Exercise;

                    var startCellValue = indexes.Cell;
                    foreach (var set in exercise.Sets)
                    {
                        if (Columns.Contains("Weight"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Weight;

                        if (Columns.Contains("Reps"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Reps;

                        if (Columns.Contains("Time"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Time;

                        if (Columns.Contains("RPE") || Columns.Contains("RIR"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Rpe;

                        if (Columns.Contains("Volume"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Volume;

                        indexes.Cell = startCellValue;
                        indexes.Row += 1;
                    }

                    indexes.Cell = 1;
                    indexes.Row += 1;
                }

                indexes.Row++;
            }
        }

        private void CreateTable(
            ExcelWorksheet sheet,
            (int FromColumn, int ToColumn, int Row, int Cell, int ToRow) indexes,
            string tableName,
            (ExcelNamedStyleXml HeaderStyle, ExcelNamedStyleXml CellStyle) styles)
        {
            var table = sheet.Tables.Add(new ExcelAddressBase(indexes.Row, indexes.FromColumn, indexes.Row + indexes.ToRow, indexes.ToColumn), tableName);
            //table.TableStyle = TableStyles.Light1;
            table.DataCellStyleName = styles.CellStyle.Name;
            table.HeaderRowCellStyle = styles.HeaderStyle.Name;

            table.ShowTotal = true;

            var index = Columns.ToList().IndexOf("Volume");
            table.Columns[index].TotalsRowLabel = "Total Volume";
            table.Columns[index].TotalsRowFunction = RowFunctions.Sum;
        }
    }
}