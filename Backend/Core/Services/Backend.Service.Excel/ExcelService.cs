using System;
using System.Collections.Generic;
using System.Text;
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
                var worksheet = package.Workbook.Worksheets.Add($"{data.User.FullName} - Training data");

                var row = 0;
                foreach (var training in data.Trainings)
                {
                    var cell = 0;
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
                }
            }
        }
    }
}
