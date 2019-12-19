using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Common;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

namespace Backend.Service.Excel
{
    public class ExcelService: IExcelService
    {
        public void ExportTraining(ExportTrainingContainer data)
        {
            using (var package = new ExcelPackage())
            {
                var sheetTitle = $"{data.User.FullName} - Training data";
                var worksheet = package.Workbook.Worksheets.Add(sheetTitle);

                var row = 0;
                var cell = 0;
                foreach (var training in data.Trainings)
                {
                    foreach (var column in data.Columns)
                    {
                        worksheet.Cells[row, cell++].Value = column;
                    }

                    row += 1;
                    cell = 0;

                    worksheet.Cells[row, cell++].Value = training.Date?.ToString("dd/MM/yyyy");
                    
                    foreach (var exercise in training.Exercises)
                    {
                        worksheet.Cells[row, cell++].Value = exercise.Exercise;

                        foreach (var set in exercise.Sets)
                        {
                            worksheet.Cells[row, cell++].Value = set.Weight;
                            worksheet.Cells[row, cell++].Value = set.Reps;
                            worksheet.Cells[row, cell++].Value = set.Time;
                            worksheet.Cells[row, cell++].Value = set.Volume;

                            cell -= 4;
                            row += 1;
                        }

                        cell = 1;
                        row += 1;
                    }

                    cell = 0;

                    worksheet.Cells[row, cell].Value = "Total volume";

                    worksheet.Cells[row, cell].Formula =
                        $"Sum({new ExcelAddress(row - training.Exercises.Count(), data.Columns.Count(), row, data.Columns.Count()).Address})";
                }

                worksheet.Calculate();
                worksheet.Cells.AutoFitColumns(0);  // auto fit columns for all cells

                // set some document properties
                package.Workbook.Properties.Title = sheetTitle;
                package.Workbook.Properties.Author = "COACH"; // TODO:
                package.Workbook.Properties.Comments = "Training report from - to - ... or entire"; // TODO

                // set some extended property values
                package.Workbook.Properties.Company = "Training companion d.o.o";

                // set some custom property values
                var xmlFile = Utils.GetFileInfo($"{sheetTitle}.xlsx");
                // save our new workbook in the output directory and we are done!
                package.SaveAs(xmlFile);

                //TODO ... return something
            }
        }
    }
}
