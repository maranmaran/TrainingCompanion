using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Common;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

namespace Backend.Service.Excel
{
    public class ExcelService: IExcelService
    {
        public async Task<ExportResult> ExportTraining(ExportTrainingContainer data)
        {
            using var stream = new MemoryStream();
            using var package = new ExcelPackage(stream);

            var sheetTitle = $"{data.User.FullName} - Training data";
            var worksheet = package.Workbook.Worksheets.Add(sheetTitle);
                
            WriteTraining(worksheet, data.Columns, data.Trainings);
         
            worksheet.Calculate();
            worksheet.Cells.AutoFitColumns(0);  // auto fit columns for all cells

            // set some document properties
            package.Workbook.Properties.Title = sheetTitle;
            package.Workbook.Properties.Author = "COACH"; // TODO:
            package.Workbook.Properties.Comments = "Training report from - to - ... or entire"; // TODO

            // set some extended property values
            package.Workbook.Properties.Company = "Training companion d.o.o";

            package.Save();

            stream.Position = 0;

            var resultStream = new MemoryStream();
            await stream.CopyToAsync(resultStream);
            resultStream.Position = 0;

            return new ExportResult {
                Stream = resultStream, 
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                Title = sheetTitle
            };
        }

        private void WriteTraining(ExcelWorksheet sheet, IEnumerable<string> columns, IEnumerable<ExportTraining> trainings)
        {
            var row = 1;
            var cell = 1;
            foreach (var training in trainings)
            {
                foreach (var column in columns)
                {
                    sheet.Cells[row, cell++].Value = column;
                }

                row += 1;
                cell = 1;

                sheet.Cells[row, cell++].Value = training.Date?.ToString("dd/MM/yyyy");

                foreach (var exercise in training.Exercises)
                {
                    sheet.Cells[row, cell++].Value = exercise.Exercise;

                    foreach (var set in exercise.Sets)
                    {
                        sheet.Cells[row, cell++].Value = set.Weight;
                        sheet.Cells[row, cell++].Value = set.Reps;
                        sheet.Cells[row, cell++].Value = set.Time;
                        sheet.Cells[row, cell++].Value = set.Volume;

                        cell -= 4;
                        row += 1;
                    }

                    cell = 1;
                    row += 1;
                }

                cell = 1;

                sheet.Cells[row, cell].Value = "Total volume";

                sheet.Cells[row, cell].Formula =
                    $"Sum({new ExcelAddress(row - training.Exercises.Count(), columns.Count(), row, columns.Count()).Address})";
            }

        }
    }
}
